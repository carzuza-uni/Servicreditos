using System;
using System.Collections.Generic;
using Datos;
using Entity;

namespace Logica
{
    public class CreditoService
    {
        private readonly ConnectionManager conexion;
        private readonly CreditoRepository repository;

        public CreditoService(string connectionString)
        {
            conexion = new ConnectionManager(connectionString);
            repository = new CreditoRepository(conexion);
        }

        public GuardarCreditoResponse Guardar(Credito credito){
            try{
                credito.CalcularTotalPagar();
                conexion.Open();
                repository.Guardar(credito);
                conexion.Close();
                return new GuardarCreditoResponse(credito);
            }catch(Exception e){ 
                return new GuardarCreditoResponse($"Error de la aplicacion: {e.Message}");
            }finally{
               conexion.Close(); 
            }
        }

        public List<Credito> ConsultarTodos(){
            try{
                conexion.Open();
                var creditos = repository.ConsultarTodos();
                conexion.Close();
                return creditos;
            }catch(Exception e){
                
            }
            return null;
        }
    }

    public class GuardarCreditoResponse 
    {
        public GuardarCreditoResponse(Credito credito)
        {
            Error = false;
            Credito credito1 = credito;
        }
        public GuardarCreditoResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Credito credito { get; set; }
    }
}
