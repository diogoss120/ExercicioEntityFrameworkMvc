using Microsoft.EntityFrameworkCore.Migrations;

namespace ExercicioEntityFramework.Migrations
{
    public partial class InserirDadosIniciaisMySql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Alunos (Nome, Sexo, Email, Nascimento) values('Diogo', 'Masculino','diogo@hotmail.com','1998-09-20')");
            migrationBuilder.Sql("insert into Alunos (Nome, Sexo, Email, Nascimento) values('Vitor', 'Masculino','vitor@hotmail.com','2002-08-18')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from Alunos");
        }
    }
}
