using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Core.Interfaces.Repository;
using MISA.CukCuk.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCukTest.Base.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class BaseController<MISAEntity> : ControllerBase where MISAEntity : class
    {
        // GET: api/<BaseController>
        IBaseRepository<MISAEntity> _baseRepository;
        IBaseService<MISAEntity> _baseService;
        string tableName = typeof(MISAEntity).Name;
        public BaseController(IBaseRepository<MISAEntity> baseRepository,
        IBaseService<MISAEntity> baseService)
        {
            _baseRepository = baseRepository;
            _baseService = baseService;
        }

        /// <summary>
        /// Lấy tất cả đối tượng
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: NXChien (28/04/2021)
        [HttpGet]
        public IActionResult Get()
        {
            var entities = _baseRepository.GetAll();
            if (entities.Count() > 0)
            {
                return Ok(entities);
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// Lấy ra 1 đối tượng theo Id
        /// </summary>
        /// <param name="id">Mã đối tượng</param>
        /// <returns>entity: đối tượng có mã entityId</returns>
        /// CreatedBy: NXChien (21/04/2021)
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {

            var entity = _baseRepository.GetById(id);
            if (entity != null)
            {
                return Ok(entity);
            }
            else
            {
                return NoContent();
            }
        }



        /// <summary>
        /// Thêm 1 đối tượng 
        /// </summary>
        /// <param name="entity">đối tượng cần thêm</param>
        /// <returns></returns>
        /// CreatedBy: NXChien (21/04/2021)
        [HttpPost]
        public IActionResult Post([FromBody] MISAEntity entity)
        {
            var rowAffects = _baseService.Insert(entity);
            if (rowAffects > 0)
            {
                return StatusCode(201, rowAffects);
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// Sửa 1 đối tượng theo Id
        /// </summary>
        /// <param name="id">Mã đối tượng</param>
        /// <param name="entity">đối tượng cần sửa</param>
        /// <returns>
        ///     -Thành công: trả về customer đã sửa.
        ///     -Thất bại: NoContent
        /// </returns>
        /// CreatedBy: NXChien (21/04/2021)
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] MISAEntity entity)
        {
            // lấy tất cả property cảu đối tượng;
            var properties = typeof(MISAEntity).GetProperties();
            // Duyệt tất cả property của đối tượng
            foreach (var item in properties)
            {
                // Kiểm tra tên của property trùng với entityId thì gán giá trị cảu property = id;
                if (item.Name == $"{tableName}Id")
                {
                    item.SetValue(entity, id);
                }
            }
            var rowAffects = _baseService.Update(entity);
            if (rowAffects > 0)
            {
                return Ok(entity);
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// Xóa 1 đối tượng
        /// </summary>
        /// <param name="id">Mã đối tượng</param>
        /// <returns></returns>
        /// CreatedBy: NXChien (21/04/2021)
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var rowAffects = _baseService.Delete(id);
            if (rowAffects > 0)
            {
                return Ok("Xoas thanh cong");
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// Lọc danh sách đối tượng
        /// </summary>
        /// <param name="pageSize">Số khách hàng trong 1 trang</param>
        /// <param name="pageIndex">Trang số bao nhiêu</param>
        /// <returns></returns>
        /// Created By: NXChien 22/04/2021
        [HttpGet("Paging")]
        public IActionResult Filters(int pageSize, int pageIndex)
        {

            //Lấy tất cả bản ghi trong DB
            var limit = _baseRepository.GetAll().Count();
            //Kiểm tra nếu số khách trên trang hoặc vị trí trang < 1 thì trả về BadRequest
            if (pageSize < 1 || pageIndex < 1)
            {
                return BadRequest();
            }
            // Kiểm tra nếu số khách/trang * vị trí trang < tổng khách + số khách/trang thì trả về NoContent.
            else if (pageSize * pageIndex >= (limit + pageSize))      //limit =245 total =250        245+10
            {
                return NoContent();
            }
            var entity = _baseService.GetEntityFilter(pageSize, pageIndex);
            if (entity != null)
            {
                return Ok(entity);
            }
            else
            {
                return NoContent();
            }
        }
    }
}
