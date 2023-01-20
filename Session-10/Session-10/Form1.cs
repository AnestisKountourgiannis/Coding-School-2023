using System.Windows.Forms;

namespace Session_10 {
    public partial class Form1 : Form {

        List<Student> students;

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

            SetControlProperties();
            PopulateStudents();

        }

        private void PopulateStudents() {

            List<University> unis = GetUniversities();

            students = new List<Student>();

            Student student1 = new Student() {
                Name = "Dimitris",
                Surname = "Raptodimos",
                Gender = Student.GenderEnum.Male,
                Age = 40,
                Undergraduate = false,
                UniversityID = unis[0].ID,
            };
            students.Add(student1);

            Student student2 = new Student() {
                Name = "Fotis",
                Surname = "Chrysoulas",
                Gender = Student.GenderEnum.Male,
                Age = 44,
                Undergraduate = true,
                UniversityID = unis[1].ID
            };
            students.Add(student2);


            bsStudents.DataSource = students;


            //Student student2 = new Student() {
            //    Name = "Dimitris",
            //    Surname = "Raptodimos",
            //    Gender = Student.GenderEnum.Male,
            //    Age = 40,
            //    Undergraduate = false
            //};

            //List<Student> students2 = new List<Student>() {
            //   student2
            //};

        }

        private List<University> GetUniversities() {


            Guid id = Guid.Parse("{72F9974A-370C-4FCE-AD99-9A73FC089E60}");

            University uni1 = new University(id) {
                Name = "NTUA",
                Region = "Athens"
            };

            id = Guid.Parse("{D3DB7E60-9BDA-41F3-9FDE-A39C77FE03A9}");
            University uni2 = new University(id) {
                Name = "UNIPI",
                Region = "Peiraeus"
            };

            University uni3 = new University(Guid.Empty) {
            };

            List<University> universities = new List<University>() { uni1, uni2, uni3 };
            return universities;
        }

        private void SetControlProperties() {

            grvStudents.AutoGenerateColumns = false;
            grvStudents.DataSource = bsStudents;

            DataGridViewComboBoxColumn colGender = grvStudents.Columns["colGender"] as DataGridViewComboBoxColumn;
            colGender.Items.Add(Student.GenderEnum.Male);
            colGender.Items.Add(Student.GenderEnum.Female);
            colGender.Items.Add(Student.GenderEnum.Other);

            DataGridViewComboBoxColumn colUniversity1 = grvStudents.Columns["colUniversity"] as DataGridViewComboBoxColumn;
            colUniversity1.DataSource = GetUniversities();
            colUniversity1.DisplayMember = "Name";
            colUniversity1.ValueMember = "ID";

            grvStudents.CellContentClick += GrvStudents_CellContentClick;

        }

        private void GrvStudents_CellContentClick(object? sender, DataGridViewCellEventArgs e) {

            var grv = (DataGridView)sender;


            DataGridViewButtonColumn col = grv.Columns[e.ColumnIndex] as DataGridViewButtonColumn;

            if (col != null && col.Name == "colShowID" && e.RowIndex >= 0) {
                Student student = grv.CurrentRow.DataBoundItem as Student;
                MessageBox.Show($"The ID of student {student.Surname} {student.Name} is {student.ID}");
            }
        }

        private void btnOK_Click(object sender, EventArgs e) {




        }

        private void btnRefresh_Click(object sender, EventArgs e) {
            PopulateStudents();
        }

    }
}