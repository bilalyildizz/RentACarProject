using Business.Abstract;
using Business.Constants;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {

            carImage.ImagePath = FileHelperr.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);

            return new SuccessResult();

        }

        public IResult Delete(CarImage carImage)
        {

            FileHelperr.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
             return new SuccessResult("CarImage Deleted");

           
            
        }

      

        public IDataResult<List<CarImage>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<CarImage> GetById(int Id)
        {
            var result = _carImageDal.Get(c => c.Id == Id);

            return new SuccesDataResult<CarImage>(result);

        }

        public IResult Update(IFormFile formFile, CarImage carImage)
        {

            carImage.ImagePath = FileHelperr.Update(formFile,carImage.ImagePath);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();

            
      }
    }
}
