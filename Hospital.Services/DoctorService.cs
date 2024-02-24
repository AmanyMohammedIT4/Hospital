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
    public class DoctorService : IDoctorService
    {
        private IUnitOfWork _unitOfWork;

        public DoctorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddTiming(TimingViewModel timing)
        {
            var model = new TimingViewModel().ConvertViewModel(timing);
            _unitOfWork.GenericRepository<Timing>().Add(model);
            _unitOfWork.Save();
        }

        public void DeleteTiming(int TimingId)
        {
            var model = _unitOfWork.GenericRepository<Timing>().GetById(TimingId);
            _unitOfWork.GenericRepository<Timing>().Delete(model);
            _unitOfWork.Save();
        }

        public PagedResult<TimingViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new TimingViewModel();
            int totalCount;
            List<TimingViewModel> vmList = new List<TimingViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;

                var modelList = _unitOfWork.GenericRepository<Timing>().GetAll()
                    .Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<Timing>().GetAll().ToList().Count;
                vmList = ConvertModelToViewModelList(modelList);

            }
            catch (Exception)
            {
                throw;
            }
            var result = new PagedResult<TimingViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
            };
            return result;
        }

        public IEnumerable<TimingViewModel> GetAll()
        {
            var TimingList = _unitOfWork.GenericRepository<Timing>().GetAll().ToList();
            var vmList = ConvertModelToViewModelList(TimingList);
            return vmList;
        }

        public TimingViewModel GetTimingById(int TimingId)
        {
            var model = _unitOfWork.GenericRepository<Timing>().GetById(TimingId);
            var vm=new TimingViewModel();
            return vm;
        }

        public void UpdateTiming(TimingViewModel timing)
        {
            var model = new TimingViewModel().ConvertViewModel(timing);
            var ModelById = _unitOfWork.GenericRepository<Timing>().GetById(model.ID);
            ModelById.ID = timing.ID;
            ModelById.Duration = timing.Duration;
            ModelById.Doctor = timing.Doctor;
            ModelById.Status = timing.Status;
            ModelById.MoringShiftEndTime = timing.MoringShiftEndTime;
            ModelById.MoringShiftStartTime = timing.MoringShiftStartTime;
            ModelById.AfternoonShiftEndTime = timing.AfternoonShiftStartTime;
            ModelById.AfternoonShiftStartTime = timing.AfternoonShiftStartTime;

            _unitOfWork.GenericRepository<Timing>().Update(ModelById);
            _unitOfWork.Save();
        }
        private List<TimingViewModel> ConvertModelToViewModelList(List<Timing> modelList)
        {
            return modelList.Select(x => new TimingViewModel(x)).ToList();
        }
    }
}
