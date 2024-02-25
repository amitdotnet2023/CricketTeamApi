using Amit_CricketTeamBAL.Interfaces;
using Amit_CricketTeamBAL.ViewModel;
using Amit_CricketTeamDAL.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Amit_CricketTeamApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CricketTeamMasterController : ControllerBase
    {
        private readonly ICricketTeamServices _cricketTeamServices;
        public CricketTeamMasterController(ICricketTeamServices cricketTeamServices)
        {
            _cricketTeamServices = cricketTeamServices;
        }

        [HttpGet]
        [Route("CriketTeam-List")]
        public async Task<IActionResult> CriketTeamList()
        {
            try
            {
                var result = await _cricketTeamServices.CriketTeamList();
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost]
        [Route("CriketTeam-Registration")]
        public async Task<IActionResult> CriketTeamRegistration([FromBody] CriketTeamRegistrationVM entity)
        {
            try
            {
                var result = await _cricketTeamServices.CriketTeamRegistration(entity);
                if (result == 0)
                {
                    return Ok(new BaseResponse { Success = true, Message = "Registration successful!" });
                }
                else if (result == 1)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new BaseResponse { Success = false, Message = "Email id and contact number already exists!" });
                }
                else if (result == 3)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new BaseResponse { Success = false, Message = "Email id already exists!" });

                }
                else if (result == 2)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new BaseResponse { Success = false, Message = "contact number already exists!" });
                }

                else if (result == 4)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new BaseResponse { Success = false, Message = "Maximum registrations reached." });
                }
                else if (result == 5)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new BaseResponse { Success = false, Message = "Team coach already registered." });
                }
                else if (result == 6)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new BaseResponse { Success = false, Message = "Maximum team coaches reached." });
                }
                else if (result == 7)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new BaseResponse { Success = false, Message = "Captain already registered." });
                }
                else
                {
                    // 8
                    return StatusCode(StatusCodes.Status400BadRequest, new BaseResponse { Success = false, Message = "Maximum captains reached." });
                }


            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost]
        [Route("CriketTeam-Login")]
        public async Task<IActionResult> TeamLogin([FromBody] TeamLoginVM entity)
        {
            try
            {
                var result = await _cricketTeamServices.TeamLogin(entity);
                if (result == 1)
                {
                    return Ok(new BaseResponse { Success = true, Message = "Login successful!" });
                }
                else if (result == 2)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new BaseResponse { Success = false, Message = "Email id not exists!" });
                }
                else if (result == 3)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new BaseResponse { Success = false, Message = "Password not exists!" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new BaseResponse { Success = false, Message = "Email id and password not exists!" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
