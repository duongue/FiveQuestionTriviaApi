using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Domain;

namespace Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Game")]
    public class GameController : Controller
    {
        private readonly IDataService _dataService;
        private readonly IEngineService _engineService;

        public GameController(IDataService dataService, IEngineService engineService)
        {
            _dataService = dataService;
            _engineService = engineService;
        }

        [Route("GetLevels")]
        public IEnumerable<Level> GetAllLevels()
        {
            return _dataService.GetAllLevelsAsync().Result;
        }

        [Route("GetCategories")]
        public IEnumerable<Category> GetAllCategories()
        {
            return _dataService.GetAllCategoriesAsync().Result;
        }

        [Route("GetQuestions")]
        [HttpPost]
        public IEnumerable<Question> GetQuestion([FromBody]QuestionsPost post)
        //public IActionResult GetQuestion([FromBody]QuestionPost post)
        {
            //return Json(post);
            return _engineService.GetANumberOfQuestions(post.LevelId, post.CategoryId, post.NumberOfQuestions).Result;
        }

        [Route("CheckAnswer")]
        [HttpPost]
        public bool CheckAnswer([FromBody]AnswerPost post)
        {
            return _engineService.CheckAnswer(post.QuestionId, post.Answer).Result;
        }

        [Route("GetEncouragement")]
        [HttpGet]
        public Encouragement GetEncouragement(bool answeredCorrectly)
        {
            return _engineService.GetEncouragement(answeredCorrectly).Result;
        }

        [Route("GetANumberOfRandomQuestions")]
        public IEnumerable<Question> GetANumberOfRandomQuestions(int numQuest)
        {
            return _engineService.GetANumberOfRandomQuestions(numQuest).Result;
        }
    }

    public class QuestionsPost
    {
        public int LevelId { get; set; }
        public int CategoryId { get; set; }
        public int NumberOfQuestions { get; set; }
    }

    public class AnswerPost
    {
        public int QuestionId { get; set; }
        public string Answer { get; set; }
    }
}