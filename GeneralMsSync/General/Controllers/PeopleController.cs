using CMSShared;

using DataLayer.Models;
using DataLayer.Repositiory;

using Microsoft.AspNetCore.Mvc;

using System.ComponentModel.DataAnnotations;

namespace ChurchManagementSystem.Controllers
{
    [ApiController]
    [Route("api")]
    public class PeopleController : Controller
    {
        private readonly IPeopleRepository mPeopleRepository;
        private readonly ILogger<AuthController> mLogger;

        public PeopleController(IPeopleRepository peopleRepository, ILogger<AuthController> logger)
        {
            mPeopleRepository = peopleRepository;
            mLogger = logger;
        }

        [HttpPost("/api/People/GetPeople")]
        public async Task<IActionResult> GetPeople([Required] ulong Id)
        {
            if (0 == Id)
            {
                return Json(new Result
                {
                    Status = EResultStatus.Error,
                    Message = "The provided id is not valid!"
                });
            }

            try
            {
                var data = await mPeopleRepository.GetPeopleEntry(Id);

                return Json(new Result
                {
                    Data = data
                });
            }
            catch (Exception ex)
            {
                mLogger.LogError(ex, ex.Message);
            }

            return Json(new Result
            {
                Status = EResultStatus.Error,
                Message = "An error occurrend, please contact support if this persists!"
            });
        }

        [HttpPost("/api/People/GetPeoplePage")]
        public async Task<IActionResult> GetPeoplePage([FromBody] PeopleFilterParams filterParams, [FromQuery]string term)
        {
            if (false == ModelState.IsValid)
            {
                return Json(new Result
                {
                    Status = EResultStatus.Error,
                    Message = "Mandatory data not provided!"
                });
            }

            try
            {
                filterParams.Name = term;

                var data = await mPeopleRepository.FilterPeople(filterParams);
                return Json(data);
            }
            catch (Exception ex)
            {
                mLogger.LogError(ex, ex.Message);
            }

            return Json(new Result
            {
                Status = EResultStatus.Error,
                Message = "An error occurrend, please contact support if this persists!"
            });
        }

        [HttpPost("/api/People/CreatePeople")]
        public async Task<IActionResult> CreatePeople([FromBody] ChurchManagementSystem.Models.People data)
        {
            try
            {
                var createResult = await mPeopleRepository.Create(new People()
                {
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    Gender = data.Gender,
                    DateOfJoin = data.DateOfJoin,
                    DOB = data.DOB,
                    DateOfBaptize = data.DateOfBaptize,
                    DateOfDecease = data.DateOfDecease,
                    MaritalStatus = data.MaritalStatus,
                    SocialStatus = data.SocialStatus,
                    Type = data.Type,
                    Role = data.Role,
                    AdditionalRolesFlags = data.AdditionalRolesFlags,
                    JoinProcessType = data.JoinProcessType,
                    Address = data.Address,
                    PhoneNumber = data.PhoneNumber,
                    Email = data.Email,
                    HolySpiritBaptized = data.HolySpiritBaptized,
                    Status = EPeopleStatus.Active,
                });

                return Json(new Result
                {
                    Status = createResult ? EResultStatus.Success : EResultStatus.ObjectCreationFailure
                });
            }
            catch (Exception ex)
            {
                mLogger.LogError(ex, ex.Message);
            }

            return Json(new Result
            {
                Status = EResultStatus.Error,
                Message = "An error occurrend, please contact support if this persists!"
            });
        }

        [HttpPost("/api/People/UpdatePeople")]
        public async Task<IActionResult> UpdatePeople([FromBody] ChurchManagementSystem.Models.People data)
        {
            if (false == data.Id.HasValue || 0 == data.Id)
            {
                return Json(new Result
                {
                    Status = EResultStatus.Error,
                    Message = "The provided id is not valid!"
                });
            }

            if (false == data.Status.HasValue)
            {
                return Json(new Result
                {
                    Status = EResultStatus.Error,
                    Message = "The provided status is not valid!"
                });
            }

            try
            {
                var createResult = await mPeopleRepository.Update(new People()
                {
                    Id = data.Id.Value,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    Gender = data.Gender,
                    DateOfJoin = data.DateOfJoin,
                    DOB = data.DOB,
                    DateOfBaptize = data.DateOfBaptize,
                    DateOfDecease = data.DateOfDecease,
                    MaritalStatus = data.MaritalStatus,
                    SocialStatus = data.SocialStatus,
                    Type = data.Type,
                    Role = data.Role,
                    AdditionalRolesFlags = data.AdditionalRolesFlags,
                    JoinProcessType = data.JoinProcessType,
                    Address = data.Address,
                    PhoneNumber = data.PhoneNumber,
                    Email = data.Email,
                    HolySpiritBaptized = data.HolySpiritBaptized,
                    Status = data.Status.Value,
                });

                return Json(new Result
                {
                    Status = createResult ? EResultStatus.Success : EResultStatus.ObjectCreationFailure
                });
            }
            catch (Exception ex)
            {
                mLogger.LogError(ex, ex.Message);
            }

            return Json(new Result
            {
                Status = EResultStatus.Error,
                Message = "An error occurrend, please contact support if this persists!"
            });
        }
    }
}
