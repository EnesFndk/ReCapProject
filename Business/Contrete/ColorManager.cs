﻿using Business.Abstract;
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

        public void Add(Color color)
        {
            _colorDal.Add(color);
        }

        public void Delete(Color color)
        {
            _colorDal.Delete(color);
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public Color GetById(int colorId)
        {
            return _colorDal.Get(c=> c.Id == colorId);
        }

        public void Update(Color color)
        {
            _colorDal.Update(color);
        }
    }
}