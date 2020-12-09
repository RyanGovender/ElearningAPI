using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElearningProjectBusiness.Implementation.Global;
using ElearningProjectModels.Models;
using ElearningProjectRepository.Implementation;
using ElearningProjectServices.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElearningProjectAdminAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class LearningPathController : ControllerBase
    {
        private IUnitOfWorkService _unitOfWork;
        public LearningPathController(IUnitOfWorkService unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _unitOfWork.LearningPathService.GetAll();
            return result.Any() ? StatusCode(200, result) : StatusCode(400, result);
        }

        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Post([FromBody] LearningPath learningPath)
        {
            if (learningPath == null) return StatusCode(400,false);
            var result = await _unitOfWork.LearningPathService.Inset(learningPath);
            return result ? StatusCode(200, result) : StatusCode(400, result);
        }

        [HttpPut]
        [Route("Put")]
        public async Task<IActionResult> Put([FromBody] LearningPath learningPath)
        {
            if (learningPath == null) return StatusCode(400);
            var result = await _unitOfWork.LearningPathService.Update(learningPath);
            Elastic.LogInformation(learningPath,learningPath);
            return result ? StatusCode(200, result) : StatusCode(400, result);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int?id)
        {
            if (!id.HasValue) return StatusCode(400,false);
            var result = await _unitOfWork.LearningPathService.Delete(id);
            return result ? StatusCode(200, result) : StatusCode(404, result);
        }

        [HttpGet] //Random Test Method for knockout project
        [Route("GetAll")]
        public List<Products> GetAll()
        {
            var data = new List<Products>() {

                new Products(1,"Xbox one",2500,50),
                new Products(2,"Xbox One S",3500,40),
                new Products(3,"PS4",4000,35)
            };

            return data;
        }
    }
}