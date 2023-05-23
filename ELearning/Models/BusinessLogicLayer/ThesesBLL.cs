using ELearning.Models.Data;
using ELearning.Models.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ELearning.Models.BusinessLogicLayer
{
    internal class ThesesBLL
    {
        public ObservableCollection<Thesis> ThesesList { get; set; }
        private ThesisRepository thesisRepository;

        public ThesesBLL()
        {
            thesisRepository = new ThesisRepository(DataService.context);
            ThesesList = new ObservableCollection<Thesis>(thesisRepository.GetAll());
        }

        public void AddThesis(Thesis thesis)
        {
            if (thesis != null)
            {
                Thesis found = ThesesList.FirstOrDefault((that) => that.Course == thesis.Course);
                if (found == null)
                {
                    thesisRepository.Insert(thesis);
                    ThesesList.Add(thesisRepository.FindByCourse(thesis.Course));
                }
                else
                {
                    if (found.Classes.IsNullOrEmpty())
                    {
                        found.Classes = new List<Class>();
                    }
                    found.Classes.Add(thesis.Classes[0]);
                    thesisRepository.Update(found);
                }
            }
            else
            {
                MessageBox.Show("Please add required arguments!");
            }
        }

        public void DeleteThesis(Thesis thesis)
        {
            if (thesis == null)
            {
                MessageBox.Show("You didn't select any thesis!");
                return;
            }

            ThesesList.Remove(thesis);
            thesisRepository.Remove(thesis);
        }

        public void DeleteClassFromThesis(Course course, Class @class)
        {
            Thesis found = thesisRepository.FindByCourse(course);
            if (found == null)
            {
                found.Classes.Remove(@class);
                @class.Theses.Remove(found);
                thesisRepository.Update(found);
                if (found.Classes.Count == 0)
                {
                    DeleteThesis(found);
                }
            }
        }

        public Thesis FindByCourse(Course course)
        {
            return thesisRepository.FindByCourse(course);
        }
    }
}
