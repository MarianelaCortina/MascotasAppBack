﻿using AutoMapper;
using BE_CrudMascotas.Models;
using BE_CrudMascotas.Models.DTO;
using BE_CrudMascotas.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE_CrudMascotas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotaController : ControllerBase
    {
        
        private readonly IMapper _mapper;
        private readonly IMascotaRepository _mascotaRepository;
        public MascotaController( IMapper mapper, IMascotaRepository mascotaRepository)
        {
            _mapper = mapper;
            _mascotaRepository = mascotaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listMascotas = await _mascotaRepository.GetListMascotas();

                var listMascotasDto = _mapper.Map<IEnumerable<MascotaDTO>>(listMascotas);

                return Ok(listMascotasDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var mascota = await _mascotaRepository.GetMascotaById(id);

                if (mascota == null)
                {
                    return NotFound();
                }
                var mascotaDto = _mapper.Map<MascotaDTO>(mascota);

                return Ok(mascotaDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var mascota = await _mascotaRepository.GetMascotaById(id);

                if (mascota == null)
                {
                    return NotFound();
                }
                await _mascotaRepository.DeleteMascota(mascota);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(MascotaDTO mascotaDTO)
        {
            try
            {
                var mascota = _mapper.Map<Mascota>(mascotaDTO);

                mascota.FechaCreacion = DateTime.Now;

                mascota = await _mascotaRepository.AddMascota(mascota);
               

                var mascotaItemDto = _mapper.Map<MascotaDTO>(mascota);

                return CreatedAtAction("Get", new { id = mascotaItemDto.Id }, mascotaItemDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, MascotaDTO mascotaDTO)
        {
            try
            {
                var mascota = _mapper.Map<Mascota>(mascotaDTO);

                if (id != mascota.Id)
                {
                    return BadRequest();
                }
                var mascotaItem = await _mascotaRepository.GetMascotaById(id);

                if (mascotaItem == null)
                {
                    return NotFound();
                }

                await _mascotaRepository.UpdateMascota(mascota);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
