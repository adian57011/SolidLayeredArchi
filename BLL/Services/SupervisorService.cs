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

        public static bool ConfirmProject(int id)
        {
            var data = from u in DataAccessFactory.EnrollmentData().Get()
                       where id == u.P_Id
                       select u;
            
            //could have also written as return data.count() > 2
            if(data.Count()>2)
            {
                var obj = DataAccessFactory.ProjectData().Get(id);
                if(obj.Status == "Open")
                {
                    obj.Status = "In progress";
                    return DataAccessFactory.ProjectData().Update(obj);
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }

        public static List<ProjectDto>Get()
        {
            var data = (from p in DataAccessFactory.ProjectData().Get()
                       where p.Status.Equals("Open")
                       select p).ToList();

            var config = new MapperConfiguration(cfg =>
             {
                 cfg.CreateMap<Project, ProjectDto>();
             });

            var mapper = new Mapper(config);
            var convert = mapper.Map <List< ProjectDto >> (data);
            return convert;
        }

        public static List<ProjectDto>GetInProgress()
        {
            var data = (from p in DataAccessFactory.ProjectData().Get()
                        where p.Status.Equals("In progress")
                        select p).ToList();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Project, ProjectDto>();
            });

            var mapper = new Mapper(config);
            var convert = mapper.Map<List<ProjectDto>>(data);
            return convert;
        }

        public static List<EnrollmentDto> ViewProgress(int id)
        {
            var data = (from p in DataAccessFactory.EnrollmentData().Get()
                        where p.Id == id && p.Projects.Status.Equals("In progress")
                        select p).ToList();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Enrollment, EnrollmentDto>();
            });
            var mapper = new Mapper(config);
            var convert = mapper.Map<List<EnrollmentDto>>(data);
            return convert;
        }
    }
}
