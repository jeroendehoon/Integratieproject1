﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integratieproject1.Domain.Datatypes;
using Integratieproject1.Domain.Ideations;
using Integratieproject1.Domain.Projects;
using Integratieproject1.Domain.Surveys;
using Integratieproject1.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Integratieproject1.DAL
{
  public class CityOfIdeasDbInitializer
  {
    private static bool hasRunDuringAppExecution = false;
    public static void Initialize(CityOfIdeasDbContext context
    , bool dropCreateDatabase = false)
    {
      if (!hasRunDuringAppExecution)
      {
       
        if (dropCreateDatabase)
          context.Database.EnsureDeleted();
        
        if (context.Database.EnsureCreated())
          Seed(context);
        
        hasRunDuringAppExecution = true;
      }
      
    }

    private static void Seed(CityOfIdeasDbContext ctx)
    {
      var previousBehaviour = ctx.ChangeTracker.QueryTrackingBehavior;
      // Stel gedrag 'tracked-entities' in
      ctx.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
      
      Address address = new Address {City = "testCity", Street = "testStreet", HouseNr = "1", ZipCode = "0000"};
      Location location = new Location {Address = address, LocationName = "test1"};
      Position position = new Position {Altitude = 0.0, Longitude = 0.0};
      
      
      Platform platform = new Platform
      {
        PlatformName = "test1",
        Address = address
      };

      Project project = new Project
      {
        ProjectName = "test1",
        StartDate = DateTime.Today,
        EndDate = DateTime.Today.AddYears(1),
        Platform = platform,
        Objective = "test1",
        Description = "test1",
        Status = "Phase1",
        Location = location
      };
      Project project2 = new Project
      {
        ProjectName = "test2",
        StartDate = DateTime.Today,
        EndDate = DateTime.Today.AddYears(1),
        Platform = platform,
        Objective = "test2",
        Description = "test2",
        Status = "Phase2",
        Location = location
      };
      Phase phase = new Phase
      {
        PhaseNr = 1,
        PhaseName = "phasetest1",
        Description = "phasedescriptiontest1",
        StartDate = DateTime.Today,
        EndDate = DateTime.Today.AddMonths(1),
        Project = project
      };
      Ideation ideation = new Ideation
      {
        CentralQuestion = "ideationtest1", 
        InputIdeation = true, 
        Phase = phase
      };

      
      Person person = new Person
      {
        Email = "testPerson1@test.com",
        Platform = platform,
        Password = "test1",
        RoleType = RoleType.LOGGEDINUSER,
        ZipCode = "0000",
        Verified = false,
        LastName = "testPerson1",
        FirstName = "testPerson1",
        BirthDate = new DateTime(1000,1,1)
      };
      Organisation organisation = new Organisation
      {
        Email = "testOrganisation1@test.com",
        Platform = platform,
        Password = "test1",
        RoleType = RoleType.LOGGEDINUSER,
        ZipCode = "0000",
        Verified = true,
        OrganisationName = "testOrganisation1",
      };
      Person admin = new Person
      {
        Email = "testAdmin1@test.com",
        Platform = platform,
        Password = "test1",
        RoleType = RoleType.ADMIN,
        ZipCode = "0000",
        Verified = false,
        LastName = "testAdmin1",
        FirstName = "testAdmin1",
        BirthDate = new DateTime(1000,1,1)
      };
      
      Idea idea = new Idea
      {
        Title = "testIdea1",
        Ideation = ideation,
        LoggedInUser = person
      };
      Idea idea2 = new Idea
      {
        Title = "testIdea2",
        Ideation = ideation,
        LoggedInUser = organisation,
      };
      Reaction reaction = new Reaction
      {
        Idea = idea,
        ReactionText = "reactionTest1",
        LoggedInUser = person
      };
      Vote vote = new Vote
      {
        VoteType = VoteType.VOTE,
        User = person,
        Confirmed = true,
        Idea = idea
      };
      Like like = new Like
      {
        Reaction = reaction,
        LoggedInUser = person
      };

      #region Survey

 Survey survey = new Survey
      {
        Title = "SurveyTest",
        Phase = phase
      };
      Question openQuestion = new Question
      {
        QuestionNr = 1,
        Survey = survey,
        QuestionType = QuestionType.OPEN,
        QuestionText = "Wat is het belangrijkste voor dit plein?"
      };
      
      Question radioQuestion = new Question
      {
        QuestionNr = 2,
        Survey = survey,
        QuestionType = QuestionType.RADIO,
        QuestionText = "Voor wie is het plein het belangrijkste?"
      };
      
      Question checkQuestion = new Question
      {
        QuestionNr = 3,
        Survey = survey,
        QuestionType = QuestionType.CHECK,
        QuestionText = "Wat zou je graag willen doen op dit plein?"
      };
      
      Question dropQuestion = new Question
      {
        QuestionNr = 4,
        Survey = survey,
        QuestionType = QuestionType.DROP,
        QuestionText = "Hoe belangrijk is dit plein voor jou?"
      };
      
      Question emailQuestion = new Question
      {
        QuestionNr = 5,
        Survey = survey,
        QuestionType = QuestionType.EMAIL,
        QuestionText = "Geef je email om je stem te bevestigen!"
      };
      
      Answer open = new Answer
      {
        TotalTimesChosen = 0,
        Question = openQuestion,
        AnswerText = ""
      };
      
      Answer radio1 = new Answer
      {
        TotalTimesChosen = 0,
        Question = radioQuestion,
        AnswerText = "Jongeren"
      };
      
      Answer radio2 = new Answer
      {
        TotalTimesChosen = 0,
        Question = radioQuestion,
        AnswerText = "Volwassenen"
      };
      
      Answer radio3 = new Answer
      {
        TotalTimesChosen = 0,
        Question = radioQuestion,
        AnswerText = "Ouderen"
      };
      
      Answer radio4 = new Answer
      {
        TotalTimesChosen = 0,
        Question = radioQuestion,
        AnswerText = "Iedereen"
      };
      
      Answer check1 = new Answer
      {
        TotalTimesChosen = 0,
        Question = checkQuestion,
        AnswerText = "Sporten"
      };
      
      Answer check2 = new Answer
      {
        TotalTimesChosen = 0,
        Question = checkQuestion,
        AnswerText = "Spelen"
      };
      
      Answer check3 = new Answer
      {
        TotalTimesChosen = 0,
        Question = checkQuestion,
        AnswerText = "Ontspannen"
      };
      
      Answer check4 = new Answer
      {
        TotalTimesChosen = 0,
        Question = checkQuestion,
        AnswerText = "Geen mening"
      };
      
      Answer drop1 = new Answer
      {
        TotalTimesChosen = 0,
        Question = dropQuestion,
        AnswerText = "Niet belangrijk"
      };
      
      Answer drop2 = new Answer
      {
        TotalTimesChosen = 0,
        Question = dropQuestion,
        AnswerText = "Beetje belangrijk"
      };
      
      Answer drop3 = new Answer
      {
        TotalTimesChosen = 0,
        Question = dropQuestion,
        AnswerText = "Vrij belangrijk"
      };
      
      Answer drop4 = new Answer
      {
        TotalTimesChosen = 0,
        Question = dropQuestion,
        AnswerText = "Heel belangrijk"
      };
      
      Answer email = new Answer
      {
        TotalTimesChosen = 0,
        Question = emailQuestion,
        AnswerText = ""
      };
      

      #endregion
     
      AdminProject adminProject = new AdminProject
      {
        Admin = admin,
        Project = project
      };
      AdminProject adminProject2 = new AdminProject
      {
        Admin = admin,
        Project = project2
      };
      admin.AdminProjects = new List<AdminProject>(){adminProject, adminProject2};
      platform.Users = new List<User>(){person, organisation,admin};
      reaction.Likes = new List<Like>(){like};
      idea.Reactions = new List<Reaction>(){reaction};
      idea.Votes = new List<Vote>(){vote};
      //ctx.Answers.Add(answer);
      openQuestion.Answers = new List<Answer>(){open};
      radioQuestion.Answers = new List<Answer>(){radio1, radio2, radio3, radio4};
      checkQuestion.Answers = new List<Answer>(){check1, check2, check3, check4};
      dropQuestion.Answers = new List<Answer>(){drop1, drop2, drop3, drop4};
      emailQuestion.Answers = new List<Answer>(){email};
      //ctx.Questions.Add(question);
      survey.Questions = new List<Question>(){openQuestion, radioQuestion, checkQuestion, dropQuestion, emailQuestion};
      //ctx.Surveys.Add(survey);
      phase.Surveys = new List<Survey>(){survey};
      //ctx.Ideas.Add(idea);
      ideation.Ideas = new List<Idea>(){idea,idea2};
      //ctx.Ideations.Add(ideation);
      phase.Ideations = new List<Ideation>(){ideation};
      //ctx.Phases.Add(phase);
      project.Phases = new List<Phase>() {phase};
      //ctx.Projects.AddRange(project,project2);
      platform.Projects = new List<Project>(){project, project2};
      ctx.Platforms.Add(platform);
            
      
      
      //platform.Projects.Add(project2);    
      
      
      
      
      
      
      
       
      ctx.SaveChanges();
      Console.WriteLine("seed");
      
      foreach (var entry in ctx.ChangeTracker.Entries().ToList())
        entry.State = EntityState.Detached;
            
      // Herstel gedrag 'ChangTracker.QueryTrackingBehavior'
      ctx.ChangeTracker.QueryTrackingBehavior = previousBehaviour;
    }
  }
}
