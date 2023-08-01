using AutoMapper;
using BLL.Dtos;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SupervisorService
    {
        public static bool CreateProject(ProjectDto obj)
        {
            obj.Status = "Open";

            //map config
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProjectDto, Project>();
            });

            //mapper called
            var mapper = new Mapper(config);

            //converted data
            var convert = mapper.Map<Project>(obj);

            //data acces layer interface called from bll
            return DataAccessFactory.ProjectData().Create(convert);
        }
    }
}
