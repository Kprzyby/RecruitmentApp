using Common.Listing;
using HeRoBackEnd.ViewModels.Recruitment;
using Microsoft.AspNetCore.Mvc;
using Services.Services;
using Services.DTOs.Recruitment;
using Data.Entities;
using AutoMapper;
using Common.Enums;
using System.Security.Claims;

namespace HeRoBackEnd.Controllers
{
    [ApiController]
    public class RecruitmentController : BaseController
    {
        private readonly RecruitmentService service;
        private readonly IMapper mapper;

        public RecruitmentController(RecruitmentService service, IMapper map)
        {
            this.service = service;
            mapper = map;
        }

        /// <summary>
        /// Returns a list of recruitments
        /// </summary>
        /// <param name="recruitmentListFilterViewModel">Object containing information about the filtering</param>
        /// <returns>Object of the JsonResult class representing the IEnumerable collection of recruitments in he JSON format</returns>
        [HttpPost]
        [Route("Recruitment/GetList")]
        public IActionResult GetList(RecruitmentListFilterViewModel recruitmentListFilterViewModel)
        {
            Paging paging = recruitmentListFilterViewModel.Paging;
            SortOrder sortOrder = recruitmentListFilterViewModel.SortOrder;
            RecruitmentFiltringDTO recruitmentFiltringDTO
                = new RecruitmentFiltringDTO(
                    recruitmentListFilterViewModel.Name,
                    recruitmentListFilterViewModel.Description,
                    recruitmentListFilterViewModel.BeginningDate,
                    recruitmentListFilterViewModel.EndingDate);

            IEnumerable<ReadRecruitmentDTO> recruitments = service.GetRecruitments(paging, sortOrder, recruitmentFiltringDTO);
            JsonResult result = new JsonResult(recruitments);

            if (result == null) return BadRequest("Something went wrong!");

            return new JsonResult(result);
        }

        



        /// <summary>
        /// Returns a recruitment specified by an id
        /// </summary>
        /// <param name="recruitmentId">Id of an recruitment</param>
        /// <returns>Object of the JsonResult class representing a recruitment in the JSON format</returns>
        [HttpGet]
        [Route("Recruitment/Get/{recruitmentId}")]
        public IActionResult Get(int recruitmentId)
        {
            ReadRecruitmentDTO recruitment = service.GetRecruitment(recruitmentId);

            if (recruitment == null)
            {
                return BadRequest("There is no such recruitment!");
            }

            JsonResult result = new JsonResult(recruitment);

            return result;
        }

        /// <summary>
        /// Creates a recruitment
        /// </summary>
        /// <param name="newRecruitment">Contains information about a new recruitment</param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        [Route("Recruitment/Create")]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(RecruitmentCreateViewModel newRecruitment)
        {

            CreateRecruitmentDTO dto = mapper.Map<CreateRecruitmentDTO>(newRecruitment);
            int id = GetUserId();

            dto.CreatedById = id;
            dto.CreatedDate = DateTime.Now;
            dto.LastUpdatedById = id;
            dto.LastUpdatedDate = DateTime.Now;

            int result = service.AddRecruitment(dto);

            if (result == -1) return BadRequest("Wrong data!");

            return Ok("Recruitment created successfully");
        }

        /// <summary>
        /// Updates a recruitment specified by an id
        /// </summary>
        /// <param name="recruitmentId">Id of a recruitment</param>
        /// <param name="recruitment">Contains new information about a recruitment</param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        [Route("Recruitment/Edit/{recruitmentId}")]
        //[ValidateAntiForgeryToken]
        public IActionResult Edit(int recruitmentId, RecruitmentEditViewModel recruitment)
        {
            UpdateRecruitmentDTO dto = mapper.Map<UpdateRecruitmentDTO>(recruitment);
            int id = GetUserId();

            dto.LastUpdatedById = id;
            dto.LastUpdatedDate = DateTime.Now;

            int result = service.UpdateRecruitment(recruitmentId, dto);

            if (result == -1) return BadRequest("Wrong data!");

            return Ok("Recruitment updated successfully");
        }

        /// <summary>
        /// Ends a recruitment specified by an id
        /// </summary>
        /// <param name="recruitmentId">Id of a recruitment</param>
        /// <returns>IActionResult</returns>
        [HttpGet]
        [Route("Recruitment/End/{recruitmentId}")]
        //[ValidateAntiForgeryToken]
        public IActionResult End(int recruitmentId)
        {
            EndRecruimentDTO dto = new EndRecruimentDTO(recruitmentId);
            int id = GetUserId();

            dto.LastUpdatedById = id;
            dto.LastUpdatedDate = DateTime.Now;
            dto.EndedById = id;
            dto.EndedDate = DateTime.Now;
            int result = service.EndRecruitment(dto);

            if (result == -1) return BadRequest("There is no such recruitment!");

            return Ok("Recruitment ended successfully");
        }
        /// <summary>
        /// Deletes a recruitment represented by an id
        /// </summary>
        /// <param name="recruitmentId">Id representing a recruitment</param>
        /// <returns>IActionResult</returns>
        [HttpGet]
        [Route("Recruitment/Delete/{recruitmentId}")]
        //[ValidateAntiForgeryToken]
        public IActionResult Delete(int recruitmentId)
        {
            DeleteRecruitmentDTO dto = new DeleteRecruitmentDTO(recruitmentId);
            int id = GetUserId();

            dto.LastUpdatedById = id;
            dto.LastUpdatedDate = DateTime.Now;
            dto.DeletedById = id;
            dto.DeletedDate = DateTime.Now;

            int result = service.DeleteRecruitment(dto);

            if (result == -1) return BadRequest("There is no such recruitment!");

            return Ok("Recruitment deleted successfully");
        }
    }
}
