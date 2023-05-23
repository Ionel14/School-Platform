using ELearning.Models.Data;
using ELearning.Models.Entities;
using ELearning.Models.Enums;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ELearning.Models.BusinessLogicLayer
{
    internal class ClassMastersBLL
    {
        public ObservableCollection<ClassMaster> ClassMastersList { get; set; }
        private ClassMasterRepository ClassMastersRepository = new ClassMasterRepository(DataService.context);

        public ClassMastersBLL()
        {
            ClassMastersList = new ObservableCollection<ClassMaster>(ClassMastersRepository.GetAll());
        }

        public void AddClassMaster(ClassMaster classMaster)
        {
            if (classMaster != null)
            {
                classMaster.Teacher.Person.RoleId = (int)UserRole.ClassMaster;
                ClassMastersRepository.Insert(classMaster);
                ClassMastersList.Add(ClassMastersRepository.FindToGetId(classMaster));
            }
            else
            {
                MessageBox.Show("Please add required arguments!");
            }
        }

        public void DeleteClassMaster(ClassMaster classMaster)
        {
            if (classMaster == null)
            {
                MessageBox.Show("You didn't select any classMaster!");
                return;
            }

            ClassMastersList.Remove(classMaster);
            ClassMastersRepository.Remove(classMaster);
        }
    }
}
