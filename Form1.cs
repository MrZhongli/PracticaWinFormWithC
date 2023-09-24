namespace PracticaWinForm;


using System;
using System.Windows.Forms;

public partial class Form1 : Form
{
    private TextBox txtNombre;
    private TextBox txtApellido;
    private TextBox txtEdad;
    private ComboBox cmbSexo;
    private Button btnVerInscritos;
    private Button btnCancelar;
    private Button btnInscribir;
    private Label lblTitulo;
    private Label lblNombre;
    private Label lblApellido;
    private Label lblEdad;
    private Label lblSexo;

    private List<Persona> personasInscritas = new List<Persona>();
    public Form1()
    {

        InitializeComponent();

        this.BackColor = Color.Black;

        // Agregar un Label para el título del formulario
        lblTitulo = new Label();
        lblTitulo.Text = "Formulario Inscripción";
        lblTitulo.Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);
        lblTitulo.Location = new System.Drawing.Point(150, 10);
        lblTitulo.Size = new System.Drawing.Size(200, 30);
        lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
        this.Controls.Add(lblTitulo);

        // Configurar los controles de la interfaz de usuario
        lblNombre = new Label();
        lblNombre.Text = "Nombre:";
        lblNombre.Location = new System.Drawing.Point(50, 60);
        lblNombre.Size = new System.Drawing.Size(80, 25);
        this.Controls.Add(lblNombre);

        txtNombre = new TextBox();
        txtNombre.Location = new System.Drawing.Point(150, 60);
        txtNombre.Size = new System.Drawing.Size(200, 25);
        this.Controls.Add(txtNombre);

        lblApellido = new Label();
        lblApellido.Text = "Apellido:";
        lblApellido.Location = new System.Drawing.Point(50, 100);
        lblApellido.Size = new System.Drawing.Size(80, 25);
        this.Controls.Add(lblApellido);

        txtApellido = new TextBox();
        txtApellido.Location = new System.Drawing.Point(150, 100);
        txtApellido.Size = new System.Drawing.Size(200, 25);
        this.Controls.Add(txtApellido);

        lblEdad = new Label();
        lblEdad.Text = "Edad:";
        lblEdad.Location = new System.Drawing.Point(50, 140);
        lblEdad.Size = new System.Drawing.Size(80, 25);
        this.Controls.Add(lblEdad);

        txtEdad = new TextBox();
        txtEdad.Location = new System.Drawing.Point(150, 140);
        txtEdad.Size = new System.Drawing.Size(50, 25);
        this.Controls.Add(txtEdad);

        lblSexo = new Label();
        lblSexo.Text = "Sexo:";
        lblSexo.Location = new System.Drawing.Point(50, 180);
        lblSexo.Size = new System.Drawing.Size(80, 25);
        this.Controls.Add(lblSexo);

        cmbSexo = new ComboBox();
        cmbSexo.Items.Add("Masculino");
        cmbSexo.Items.Add("Femenino");
        cmbSexo.Location = new System.Drawing.Point(150, 180);
        cmbSexo.Size = new System.Drawing.Size(150, 25);
        this.Controls.Add(cmbSexo);

        btnInscribir = new Button();
        btnInscribir.Text = "Inscribir";
        btnInscribir.Location = new System.Drawing.Point(150, 220);
        btnInscribir.Size = new System.Drawing.Size(100, 30);
        btnInscribir.Click += new EventHandler(btn_inscribirClick);
        this.Controls.Add(btnInscribir);

        // Crear el botón "Ver Inscritos"
        btnVerInscritos = new Button();
        btnVerInscritos.Text = "Ver Inscritos";
        btnVerInscritos.Location = new System.Drawing.Point(150, 260); // Posición debajo de "Inscribir"
        btnVerInscritos.Size = new System.Drawing.Size(100, 30);
        btnVerInscritos.Click += new EventHandler(btn_verInscritosClick);
        this.Controls.Add(btnVerInscritos);

        btnCancelar = new Button();
        btnCancelar.Text = "Cancelar";
        btnCancelar.Location = new System.Drawing.Point(300, 260); // Posición debajo de "Inscribir"
        btnCancelar.Size = new System.Drawing.Size(100, 30);
        btnCancelar.Click += new EventHandler(btn_cancelarClick);
        this.Controls.Add(btnCancelar);
        
        lblTitulo.ForeColor = Color.White;
        lblNombre.ForeColor = Color.White;
        lblApellido.ForeColor = Color.White;
        lblEdad.ForeColor = Color.White;
        lblSexo.ForeColor = Color.White;
        
        btnInscribir.ForeColor = Color.White;
        btnVerInscritos.ForeColor = Color.White;
        btnCancelar.ForeColor = Color.White;
    }

    // Evento del botón de inscripción
    private void btn_inscribirClick(object sender, EventArgs e)
    {
        // Crear una nueva instancia de Persona y asignar valores desde los controles
        Persona nuevaPersona = new Persona
        {
            Nombre = txtNombre.Text,
            Apellido = txtApellido.Text,
            Edad = Convert.ToInt32(txtEdad.Text),
            Sexo = cmbSexo.SelectedItem.ToString()
        };

        // Agregar la persona a la lista de inscritos
        personasInscritas.Add(nuevaPersona);

        // Limpiar los campos de entrada después de la inscripción
        txtNombre.Clear();
        txtApellido.Clear();
        txtEdad.Clear();
        cmbSexo.SelectedIndex = -1;
    }

    // Evento del botón "Ver Inscritos"
private void btn_verInscritosClick(object sender, EventArgs e)
{
    // Mostrar la lista de inscritos en una nueva ventana
    using (Form ventanaInscritos = new Form())
    {
        ListBox listBox = new ListBox();
        listBox.Dock = DockStyle.Fill;

        foreach (Persona persona in personasInscritas)
        {
            listBox.Items.Add($"Nombre: {persona.Nombre}, \nApellido: {persona.Apellido}, \nEdad: {persona.Edad}, \nSexo: {persona.Sexo}");
        }

        ventanaInscritos.Controls.Add(listBox);
        ventanaInscritos.Size = new System.Drawing.Size(400, 300);
        ventanaInscritos.StartPosition = FormStartPosition.CenterScreen;
        ventanaInscritos.Text = "Inscritos";
        ventanaInscritos.ShowDialog();
    }
}

private void btn_cancelarClick(object sender, EventArgs e){
    this.Close();
}

}
