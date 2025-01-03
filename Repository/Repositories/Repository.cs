﻿using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly AppDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<IEnumerable<T>> ObterTodosAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> ObterPorIdAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);

        if (entity != null)
        {
            // Desanexa a instância, para evitar o conflito de rastreamento
            _context.Entry(entity).State = EntityState.Detached;
        }

        return entity;
    }

    public async Task<T> AdicionarAsync(T entidade)
    {
        await _dbSet.AddAsync(entidade);
        await _context.SaveChangesAsync();
        return entidade;
    }

    public async Task<T> AtualizarAsync(T entidade)
    {
        _dbSet.Update(entidade);
        await _context.SaveChangesAsync();
        return entidade;
    }

    public async Task<bool> RemoverAsync(int id)
    {
        var entidade = await ObterPorIdAsync(id);
        if (entidade == null) return false;

        _dbSet.Remove(entidade);
        await _context.SaveChangesAsync();
        return true;
    }
}
