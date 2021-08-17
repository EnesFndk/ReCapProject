using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Contrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Contrete
{
    public class ColorManager : IColorManager
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            return new SuccessResult(Messages.ColorAdded);

            _colorDal.Add(color);
        }

        public IResult Delete(Color color)
        {
            return new SuccessResult(Messages.ColorDeleted);

            _colorDal.Delete(color);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<Color> GetById(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c=> c.Id == colorId));
        }

        public IResult Update(Color color)
        {
            return new SuccessResult(Messages.ColorModified);

            _colorDal.Update(color);
        }
    }
}
