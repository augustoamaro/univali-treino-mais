﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TreinoMais.AcessoDados.Interfaces;
using TreinoMais.Dominio.Models;

namespace TreinoMais.AcessoDados.Repositorios
{
    public class ProfessorRepositorio : RepositorioGenerico<Professor>, IProfessorRepositorio
    {
        private readonly Contexto _contexto;

        public ProfessorRepositorio(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> ProfessorExiste(string Nome)
        {
            return await _contexto.Professores.AnyAsync(p => p.Nome == Nome);
        }

        public async Task<bool> ProfessorExiste(string Nome, int ProfessorId)
        {
            return await _contexto.Professores.AnyAsync(p => p.Nome == Nome && p.ProfessorId != ProfessorId);
        }
    }
}
