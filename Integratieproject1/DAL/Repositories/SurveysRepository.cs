using System;
using System.Collections.Generic;
using System.Linq;
using Integratieproject1.DAL.Interfaces;
using Integratieproject1.Domain.Surveys;
using Microsoft.EntityFrameworkCore;

namespace Integratieproject1.DAL.Repositories
{
    public class SurveysRepository : ISurveysRepository
    {
        private readonly CityOfIdeasDbContext ctx = null;

        
        public SurveysRepository(UnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException("unitOfWork");

            ctx = unitOfWork.ctx;
        }
        
        
        // Survey methods
        public IEnumerable<Survey> GetSurveys()
        {
            return ctx.Surveys.AsEnumerable();
        }
        public Survey GetSurvey(int surveyId)
        {
            return ctx.Surveys.Include(q => q.Questions).ThenInclude(a => a.Answers).Single(s => s.SurveyId == surveyId);;
        }
        public Survey CreateSurvey(Survey survey)
        {
            ctx.Surveys.Add(survey);
            ctx.SaveChanges();
            return survey;
        }
        
        // Question methods
        public IEnumerable<Question> GetQuestions()
        {
            return ctx.Questions.AsEnumerable();
        }
        public Question GetQuestion(int questionId)
        {
            return ctx.Questions.Find(questionId);
        }
        public Question CreateQuestion(Question question)
        {
            ctx.Questions.Add(question);
            ctx.SaveChanges();
            return question;
        }
        
        // Answer methods
        public IEnumerable<Answer> GetAnswers()
        {
            return ctx.Answers.AsEnumerable();
        }
        public Answer GetAnswer(int answerId)
        {
            return ctx.Answers.Find(answerId);
        }
        public Answer CreateAnswer(Answer answer)
        {
            ctx.Answers.Add(answer);
            ctx.SaveChanges();
            return answer;
        }
    }
}