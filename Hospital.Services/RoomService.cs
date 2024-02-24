using Hospital.Models;
using Hospital.Repository.Interfaces;
using Hospital.Utilities;
using Hospital.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public class RoomService : IRoomService
    {
        private IUnitOfWork _unitOfWork;

        public RoomService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteRoom(int id)
        {
            var model = _unitOfWork.GenericRepository<Room>().GetById(id);
            _unitOfWork.GenericRepository<Room>().Delete(model);
            _unitOfWork.Save();
        }

        public PagedResult<RoomViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new RoomViewModel();
            int totalCount;
            List<RoomViewModel> vmList = new List<RoomViewModel>();
            try
            {
                int ExcludeRecord = (pageSize * pageNumber) - pageSize;

                var modelList = _unitOfWork.GenericRepository<Room>().GetAll(includeProperties:"Hospital")
                    .Skip(ExcludeRecord).Take(pageSize).ToList();

                totalCount = _unitOfWork.GenericRepository<Room>().GetAll().ToList().Count;
                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }
            var result = new PagedResult<RoomViewModel>
            {
                Data = vmList,
                TotalItems=totalCount,
                PageNumber=pageNumber,
                PageSize=pageSize

            };
            return result;
        }

        public RoomViewModel GetRoomById(int RoomID)
        {
            var model = _unitOfWork.GenericRepository<Room>().GetById(RoomID);
            var vm = new RoomViewModel(model);
            return vm;
        }
        
        public void InsertRoom(RoomViewModel Room)
        {
            var model = new RoomViewModel().ConverViewModel(Room);
            _unitOfWork.GenericRepository<Room>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateRoom(RoomViewModel Room)
        {
            var model = new RoomViewModel().ConverViewModel(Room);
            var ModelById = _unitOfWork.GenericRepository<Room>().GetById(model.Id);
            ModelById.Type = Room.Type;
            ModelById.RoomNumber = Room.RoomNumber;
            ModelById.Status = Room.Status;
            ModelById.HospitalId = Room.HospitalInfoId;

            _unitOfWork.GenericRepository<Room>().Update(ModelById);
            _unitOfWork.Save();
        }
        private List<RoomViewModel> ConvertModelToViewModelList(List<Room> modelList)
        {
            return modelList.Select(x => new RoomViewModel(x)).ToList();
        }
    }
}
