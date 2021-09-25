using System.Collections.Generic;
using HolaWeb.App.Dominio;
using System;
namespace HolaWeb.App.Persistencia.AppRepositorios
{
    public interface IRepositorioSaludos
    {
        IEnumerable<Saludo> GetAll();

        IEnumerable<Saludo> GetSaludoFiltro(string filtro);
         
        Saludo GetSaludoPorId(int Id);

        Saludo GetSaludoPorId(DateTime Id);

    }
}