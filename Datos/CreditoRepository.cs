using System.Data.SqlClient;
using System.Collections.Generic;
using Entity;
using System;

namespace Datos
{
    public class CreditoRepository
    {
        private readonly SqlConnection _connection;

        public CreditoRepository(ConnectionManager connection)
        {
            _connection = connection.conexion;
        }

        public void Guardar(Credito credito){
            using(var command = _connection.CreateCommand()){
                command.CommandText = @"Insert Into creditos (Identificacion,Nombre,CapitalInicial,TasaInteres,TiempoDuracion,TotalPagar) 
                                        values (@Identificacion,@Nombre,@CapitalInicial,@TasaInteres,@TiempoDuracion,@TotalPagar)";
                command.Parameters.AddWithValue("@Identificacion", credito.Identificacion);
                command.Parameters.AddWithValue("@Nombre", credito.Nombre);
                command.Parameters.AddWithValue("@CapitalInicial", credito.CapitalInicial);
                command.Parameters.AddWithValue("@TasaInteres", credito.TasaInteres);
                command.Parameters.AddWithValue("@TiempoDuracion", credito.TiempoDuracion);
                command.Parameters.AddWithValue("@TotalPagar", credito.TotalPagar);
                var filas = command.ExecuteNonQuery();
            }
        }

        public List<Credito> ConsultarTodos(){
            SqlDataReader reader;
            List<Credito> creditos = new List<Credito>();

            using(var command = _connection.CreateCommand()){
                command.CommandText = "select * from creditos";
                reader = command.ExecuteReader();
                if(reader.HasRows){
                    while(reader.Read()){
                        Credito credito = MapToPerson(reader);
                        creditos.Add(credito);
                    }
                }
            }
            return creditos;
        }
        
        public Credito MapToPerson(SqlDataReader reader){
            if(!reader.HasRows)
                return null;
            
            Credito credito = new Credito();
            credito.Identificacion = (string)reader["Identificacion"];
            credito.Nombre = (string)reader["Nombre"];
            credito.CapitalInicial = (decimal)reader["CapitalInicial"];
            credito.TasaInteres = (decimal)reader["TasaInteres"];
            credito.TiempoDuracion = (decimal)reader["TiempoDuracion"];            
            credito.TotalPagar = (decimal)reader["TotalPagar"];
            return credito;
        }
    }
}
