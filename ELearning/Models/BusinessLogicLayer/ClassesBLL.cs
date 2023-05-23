using ELearning.Models.Data;
using ELearning.Models.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WpfMVVMAgendaEF.Helpers;

namespace ELearning.Models.BusinessLogicLayer
{
    internal class ClassesBLL : BaseVM
    {
        public ObservableCollection<Class> ClassesList { get; set; }
        private ClassRepository ClassesRepository;

        public ClassesBLL()
        {
            ClassesRepository = new ClassRepository(DataService.context);
            SpecializationsBLL specializationsBLL = new SpecializationsBLL();
            CoursesBLL coursesBLL = new CoursesBLL();
            ClassesList = new ObservableCollection<Class>(ClassesRepository.GetAllCourses());
        }

        public void AddClass(Class @class)
        {
            if (!@class.Name.IsNullOrEmpty())
            {
                Class found = ClassesList.FirstOrDefault((that) => that.Name == @class.Name);
                if (found == null)
                {
                    ClassesRepository.Insert(@class);
                    ClassesList.Add(ClassesRepository.FindByName(@class.Name));
                }
                else
                {
                    found.Specialization = @class.Specialization;
                    found.SpecializationId = @class.SpecializationId;
                    ClassesRepository.Update(found);
                }
                NotifyPropertyChanged("ClassesList");
            }
            else
            {
                MessageBox.Show("Please add required arguments!");
            }
        }

        public void DeleteClass(Class Class)
        {
            if (Class == null)
            {
                MessageBox.Show("You didn't select any class!");
                return;
            }

            ClassesList.Remove(Class);
            ClassesRepository.Remove(Class);
            NotifyPropertyChanged("ClassesList");
        }

        public void Update(Class @class)
        {
            if (@class != null)
            {
                Class found = ClassesList.FirstOrDefault((that) => that.Name == @class.Name);
                found = @class;
                NotifyPropertyChanged("ClassesList");
                ClassesRepository.UpdateClass(@class);
            }
            else
            {
                MessageBox.Show("You didn't select any class or added required arguments!");
            }
        }

    }
}
