using System.Collections.Generic;
using Integratieproject1.Domain.Surveys;

namespace Integratieproject1.DAL.Interfaces
{
    public interface ISurveysRepository
    {
        IEnumerable<Survey> GetSurveys();
        Survey GetSurvey(int surveyId);
        Survey CreateSurvey(Survey survey);
        IEnumerable<Question> GetQuestions();
        Question GetQuestion(int questionId);
        Question CreateQuestion(Question question);
        IEnumerable<Answer> GetAnswers();
        Answer GetAnswer(int answerId);
        Answer CreateAnswer(Answer answer);
        Answer UpdateAnswer(Answer answer);
    }
}