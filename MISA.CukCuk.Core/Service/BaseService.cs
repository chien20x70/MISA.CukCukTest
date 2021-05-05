using MISA.CukCuk.Core.CustomAttribute;
using MISA.CukCuk.Core.Enums;
using MISA.CukCuk.Core.Exceptions;
using MISA.CukCuk.Core.Interfaces.Repository;
using MISA.CukCuk.Core.Interfaces.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Service
{
    public class BaseService<MISAEntity> : IBaseService<MISAEntity> where MISAEntity : class
    {
        IBaseRepository<MISAEntity> _baseRepository;
        string tableName = typeof(MISAEntity).Name;
        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        /// <summary>
        /// Lấy danh sách tất cả các đối tượng
        /// </summary>
        /// <returns>Mảng danh sách đối tượng</returns>
        /// Created By: NXCHIEN 29/04/2021
        public IEnumerable<MISAEntity> GetAll()
        {
            return _baseRepository.GetAll();
        }

        /// <summary>
        /// Lấy 1 đối tượng theo ID
        /// </summary>
        /// <param name="entityId">Mã ID của đối tượng</param>
        /// <returns>1 đối tượng có id là entityId</returns>
        /// Created By: NXCHIEN 29/04/2021
        public MISAEntity GetById(Guid entityId)
        {
            return _baseRepository.GetById(entityId);
        }

        /// <summary>
        /// Phân trang đối tượng
        /// </summary>
        /// <param name="pageSize">số đối tượng trên 1 trang</param>
        /// <param name="pageIndex">Trang số bao nhiêu</param>
        /// <returns>Mảng danh sách đối tượng</returns>
        /// Created By: NXCHIEN 29/04/2021
        public IEnumerable<MISAEntity> GetEntityFilter(int pageSize, int pageIndex)
        {
            return _baseRepository.GetEntityFilter(pageSize, pageIndex);
        }

        /// <summary>
        /// Thêm mới 1 đối tượng
        /// </summary>
        /// <param name="entity">Đối tượng cần thêm mới</param>
        /// <returns>số dòng trong bảng trong DB bị ảnh hưởng</returns>
        /// Created By: NXCHIEN 29/04/2021
        public int Insert(MISAEntity entity)
        {
            Validate(entity, HTTPType.POST);
            return _baseRepository.Insert(entity);
        }

        /// <summary>
        /// Validate dữ liệu dùng chung
        /// </summary>
        /// <param name="entity">đối tượng truyền vào</param>
        /// <param name="http">Phương thức POST or PUT</param>
        /// Created By: NXCHIEN 29/04/2021
        private void Validate(MISAEntity entity, HTTPType http)
        {
            // Lấy ra tất cả property của đối tượng
            var properties = typeof(MISAEntity).GetProperties();
            foreach (var property in properties)
            {
                // Lấy ra attribute của đối tượng
                var requiredAttribute = property.GetCustomAttributes(typeof(MISARequired), true);
                if(requiredAttribute.Length > 0)
                {
                    // Lấy ra giá trị của property
                    var propertyValue = property.GetValue(entity);
                    // Kiểm tra nếu giá trị null thì gán thành empty.
                    if(propertyValue == null)
                    {
                        propertyValue = "";
                    }
                    if (string.IsNullOrEmpty(propertyValue.ToString()))
                    {
                        // Lấy ra message lỗi của attribute.
                        var msgError = (requiredAttribute[0] as MISARequired).MsgError;
                        if (string.IsNullOrEmpty(msgError))
                        {
                            msgError = $"{property.Name} không được phép để trống!";
                        }
                        throw new CustomExceptions(msgError);
                    }
                }
                // Kiểm tra độ dài mã Code của property
                var maxLengthAttribute = property.GetCustomAttributes(typeof(MISAMaxLength), true);
                if(maxLengthAttribute.Length > 0)
                {
                    // Lấy ra giá trị của property
                    var propertyValue = property.GetValue(entity);
                    // Lấy ra giá trị truyền vào của MISAMaxLength
                    var maxLength = (maxLengthAttribute[0] as MISAMaxLength).MaxLength;
                    // Kiểm tra độ dài
                    if (propertyValue.ToString().Length > maxLength)
                    {
                        var msgError = (maxLengthAttribute[0] as MISAMaxLength).MsgError_MaxLength;
                        if (string.IsNullOrEmpty(msgError))
                        {
                            msgError = $"Độ dài của {property.Name} phải nhỏ hơn {maxLength}";
                        }
                        throw new CustomExceptions(msgError);
                    }
                }
            }


            //Check trùng mã đối tượng -- Check động : 
            //TODO: Check động chưa dùng đến vì customerGroup chưa cần check trùng.
            //var entityCode = typeof(MISAEntity).GetProperty($"{tableName}Code").GetValue(entity);
            //var entityId = typeof(MISAEntity).GetProperty($"{tableName}Id").GetValue(entity);
            //var IsCheckHttpPostOrPut = _baseRepository.CheckEntityCodeExist(entityCode.ToString(), Guid.Parse(entityId.ToString()), http);
            //if (IsCheckHttpPostOrPut == true)
            //{
            //    throw new CustomExceptions("Mã khách hàng đã tồn tại trên hệ thống!");
            //}


            // Validate dữ liệu riêng tường đối tượng
            CustomValidate(entity, http);
        }

        /// <summary>
        /// Validate dữ liệu riêng tường đối tượng
        /// </summary>
        /// <param name="entity">đối tượng truyền vào</param>
        /// <param name="http">Phương thức POST or PUT</param>
        /// Created By: NXCHIEN 29/04/2021
        protected virtual void CustomValidate(MISAEntity entity, HTTPType http)
        {

        }

        /// <summary>
        /// Sửa 1 đối tượng 
        /// </summary>
        /// <param name="entity">Đối tượng cần sửa</param>
        /// <returns>1 đối tượng đã được sửa</returns>
        /// Created By: NXCHIEN 29/04/2021
        public int Update(MISAEntity entity)
        {
            Validate(entity, HTTPType.PUT);
            return _baseRepository.Update(entity);
        }

        /// <summary>
        /// Xóa 1 đối tượng
        /// </summary>
        /// <param name="entityId">Mã ID cảu đối tượng</param>
        /// <returns>Thông báo xóa thành công</returns>
        /// Created By: NXCHIEN 29/04/2021
        public int Delete(Guid entityId)
        {
            return _baseRepository.Delete(entityId);
        }
    }
}
