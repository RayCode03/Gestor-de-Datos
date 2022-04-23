using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Agenda_Electronica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Conexion.Connection();

            dataGridView1.DataSource = DataTable();
        }

        public DataTable DataTable()
        {
            Conexion.Connection();
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM Formulario";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Connection());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Conexion.Connection();
            string insertar = "insert into Formulario (Nombre, Apellido, Fecha_de_nacimiento, Dirección, Genero, Estado_civil, Móvil, Telefono,Correo_Electronico) values (@Nombre, @Apellido, @Fecha_de_nacimiento, @Dirección, @Genero, @Estado_civil, @Móvil, @Telefono, @Correo_Electronico)";
            SqlCommand cmd1 = new SqlCommand(insertar, Conexion.Connection());
            cmd1.CommandText = insertar;
            cmd1.Parameters.AddWithValue("@Nombre", texNombre.Text);
            cmd1.Parameters.AddWithValue("@Apellido", texApellido.Text);
            cmd1.Parameters.AddWithValue("@Fecha_de_nacimiento", texFecha.Text);
            cmd1.Parameters.AddWithValue("@Dirección", texDireccion.Text);
            cmd1.Parameters.AddWithValue("@Genero", comboBoxGenero.Text);
            cmd1.Parameters.AddWithValue("@Estado_civil", comboBoxEstadoCivil.Text);
            cmd1.Parameters.AddWithValue("@Móvil", texMovil.Text);
            cmd1.Parameters.AddWithValue("@Telefono", texTelefono.Text);
            cmd1.Parameters.AddWithValue("@Correo_Electronico", texCorreo.Text);

            cmd1.ExecuteNonQuery();

            limpiar();

            MessageBox.Show("Los datos fueron agregados con exito");

            dataGridView1.DataSource = DataTable();


        }


        public void limpiar()
        {
            texNombre.Text = string.Empty;
            texApellido.Text = string.Empty;
            texFecha.Text = string.Empty;
            texDireccion.Text = string.Empty;
            comboBoxGenero.Text = string.Empty;
            comboBoxEstadoCivil.Text = string.Empty;
            texMovil.Text = string.Empty;
            texTelefono.Text = string.Empty;
            texCorreo.Text = string.Empty;


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                texId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                texNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                texApellido.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                texFecha.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                texDireccion.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                comboBoxGenero.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                comboBoxEstadoCivil.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                texMovil.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                texTelefono.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                texCorreo.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            Conexion.Connection();
            string Modificar = "UPDATE Formulario SET Nombre=@Nombre, Apellido=@Apellido, Fecha_de_nacimiento=@Fecha_de_nacimiento, Dirección=@Dirección, Genero=@Genero, Estado_civil=@Estado_civil, Móvil=@Móvil, Telefono=@Telefono,Correo_Electronico=@Correo_Electronico where Id=@Id";
            SqlCommand cmd2 = new SqlCommand(Modificar, Conexion.Connection());
            cmd2.CommandText = Modificar;
            cmd2.Parameters.AddWithValue("@Id", texId.Text);
            cmd2.Parameters.AddWithValue("@Nombre", texNombre.Text);
            cmd2.Parameters.AddWithValue("@Apellido", texApellido.Text);
            cmd2.Parameters.AddWithValue("@Fecha_de_nacimiento", texFecha.Text);
            cmd2.Parameters.AddWithValue("@Dirección", texDireccion.Text);
            cmd2.Parameters.AddWithValue("@Genero", comboBoxGenero.Text);
            cmd2.Parameters.AddWithValue("@Estado_civil", comboBoxEstadoCivil.Text);
            cmd2.Parameters.AddWithValue("@Móvil", texMovil.Text);
            cmd2.Parameters.AddWithValue("@Telefono", texTelefono.Text);
            cmd2.Parameters.AddWithValue("@Correo_Electronico", texCorreo.Text);

            cmd2.ExecuteNonQuery();

            MessageBox.Show("Los datos fueron actualizados con exito");

            dataGridView1.DataSource = DataTable();


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Conexion.Connection();
            string Eli = "delete from Formulario where Id=@Id";
            SqlCommand cmd3 = new SqlCommand(Eli, Conexion.Connection());
            cmd3.CommandText = Eli;
            cmd3.Parameters.AddWithValue("@Id", texId.Text);

            cmd3.ExecuteNonQuery();

            MessageBox.Show("Los datos fueron eliminado con exito");

            dataGridView1.DataSource = DataTable();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();

        }
    }
}
