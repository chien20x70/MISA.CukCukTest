using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Interfaces.Repository
{
    public interface IBaseRepository<MISAEntity> where MISAEntity :class
    {
        /// <summary>
        /// Lấy danh sách tất cả các đối tượng
        /// </summary>
        /// <returns></returns>
        /// Created By: 29/04/2021
        public IEnumerable<MISAEntity> GetAll();
        /// <summary>
        /// Lấy 1 đối tượng theo ID
        /// </summary>
        /// <param name="entityId">Mã ID của đối tượng</param>
        /// <returns></returns>
        /// Created By: 29/04/2021
        public MISAEntity GetById(Guid entityId);
        /// <summary>
        /// Thêm mới 1 đối tượng
        /// </summary>
        /// <param name="entity">Đối tượng cần thêm mới</param>
        /// <returns></returns>
        public int Insert(MISAEntity entity);
        /// <summary>
        /// Sửa 1 đối tượng 
        /// </summary>
        /// <param name="entity">Đối tượng cần sửa</param>
        /// <returns></returns>
        /// Created By: 29/04/2021
        public int Update(MISAEntity entity);
        /// <summary>
        /// Xóa 1 đối tượng
        /// </summary>
        /// <param name="entityId">Mã ID cảu đối tượng</param>
        /// <returns></returns>
        /// Created By: 29/04/2021
        public int Delete(Guid entityId);
        /// <summary>
        /// Phân trang đối tượng
        /// </summary>
        /// <param name="pageSize">số đối tượng trên 1 trang</param>
        /// <param name="pageIndex">Trang số bao nhiêu</param>
        /// <returns></returns>
        /// Created By: 29/04/2021
        public IEnumerable<MISAEntity> GetEntityFilter(int pageSize, int pageIndex);
    }
}
