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

        public IEnumerable<MISAEntity> GetAll()
        {
            return _baseRepository.GetAll();
        }

        public MISAEntity GetById(Guid entityId)
        {
            return _baseRepository.GetById(entityId);
        }

        public IEnumerable<MISAEntity> GetEntityFilter(int pageSize, int pageIndex)
        {
            return _baseRepository.GetEntityFilter(pageSize, pageIndex);
        }

        public int Insert(MISAEntity entity)
        {
            Validate(entity, HTTPType.POST);
            return _baseRepository.Insert(entity);
        }

        private void Validate(MISAEntity entity, HTTPType http)
        {
            var properties = typeof(MISAEntity).GetProperties();
            foreach (var property in properties)
            {
                var requiredAttribute = property.GetCustomAttributes(typeof(MISARequired), true);
                if(requiredAttribute.Length > 0)
                {
                    var propertyValue = property.GetValue(entity);
                    if (string.IsNullOrEmpty(propertyValue.ToString()))
                    {
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

            CustomValidate(entity, http);
        }

        protected virtual void CustomValidate(MISAEntity entity, HTTPType http)
        {

        }

        public int Update(MISAEntity entity)
        {
            Validate(entity, HTTPType.PUT);
            return _baseRepository.Update(entity);
        }

        public int Delete(Guid entityId)
        {
            return _baseRepository.Delete(entityId);
        }
    }
}
