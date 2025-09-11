using Microsoft.AspNetCore.Mvc;
using dotnetapp.Services;
using dotnetapp.Models;

namespace dotnetapp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApprovalController : ControllerBase
    {
        private readonly IApprovalService _service;
        public ApprovalController(IApprovalService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAllApprovals());

        [HttpGet("{id}")]
        public IActionResult Get(int id) => Ok(_service.GetApprovalById(id));

        [HttpPost]
        public IActionResult Create(Approval approval)
        {
            _service.CreateApproval(approval);
            return CreatedAtAction(nameof(Get), new { id = approval.Id }, approval);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Approval approval)
        {
            _service.UpdateApproval(id, approval);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteApproval(id);
            return NoContent();
        }
    }
}
