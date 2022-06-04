using AppClinica.Entities;
using AppClinica.Entities.DB;
using AppClinica.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppClinica.Controllers;

[Authorize]

    public class HistorialClinicaController:Controller
{
    private DbEntities _DbEntities;
    private readonly IDueñoRepositorio _dueñoRepositorio;
    private readonly IMascotaRepositorio _mascotaRepositorio;
    private readonly IHistoriaClinicaRepositorio _historiaClinicaRepositorio;
    
    
    
    public HistorialClinicaController(  DbEntities dbEntities,
                                        IDueñoRepositorio dueñoRepo,
                                        IHistoriaClinicaRepositorio historiaClinicaRepo,
                                        IMascotaRepositorio mascotaRepo)
    {
        _DbEntities = dbEntities;
        _dueñoRepositorio = dueñoRepo;
        _historiaClinicaRepositorio = historiaClinicaRepo;
        _mascotaRepositorio = mascotaRepo;
    }
    public IActionResult Listar()
    {
        var item = _DbEntities.HistoriasClinicas.Include(o =>o.Mascota)
                                                                                .Include(o=>o.Mascota.Dueño);
        return View(item);
    }
    [HttpGet]
    public IActionResult CrearH()
    {

        return View();
    }
    [HttpPost]
    public IActionResult CrearH(Dueños dueño)
    {
        _dueñoRepositorio.guardarDueños(dueño);
        return RedirectToAction("CrearMascota", "HistorialClinica");
    }

    [HttpGet]
    public IActionResult CrearMascota()
    {
        return View();
    }
    [HttpPost]
    public IActionResult CrearMascota(Mascota mascota)
    {
        var dueños = _dueñoRepositorio.listarDueños();
        foreach (var item in dueños)
        {
            mascota.IdDueño = item.Id;
        }
        _mascotaRepositorio.agregarMascota(mascota);
        return RedirectToAction("CrearH", "HistorialClinica");
    }
    [HttpGet]
    public IActionResult CrearHistoria()
    {
        return View();
    }
    [HttpPost]
    public IActionResult CrearHistoria(HistoriaClinica historiaClinica)
    {
        var mascotas = _mascotaRepositorio.listarMascotas();
        foreach (var item in mascotas)
                {
                    historiaClinica.IdMascota = item.ID;
                }
        _historiaClinicaRepositorio.guardarHistoriaClinica(historiaClinica);
        return RedirectToAction("Listar", "HistorialClinica");
    }
}