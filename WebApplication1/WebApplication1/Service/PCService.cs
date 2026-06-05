using Microsoft.EntityFrameworkCore;
using WebApplication1.DTOs;
using WebApplication1.Exceptions;
using WebApplication1.Infrastructure;
using WebApplication1.Models;

namespace WebApplication1.Service;

public class PCService(DatabaseContext ctx) : IPCService
{
    public async Task<IEnumerable<PCResponse>> GetAllPC(CancellationToken cancellationToken)
    {
        return await ctx.PCs.Select(pc => new PCResponse(
            pc.Id,
            pc.Name,
            pc.Weight,
            pc.Warranty,
            pc.CreatedAt,
            pc.Stock
        )).ToListAsync(cancellationToken);
    }

    public async Task<PCDetailsResponse> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await ctx.PCs.Where(pc => pc.Id == id)
            .Select(e => new PCDetailsResponse(
                e.Id,
                e.Name,
                e.Weight,
                e.Warranty,
                e.CreatedAt,
                e.Stock
            )).FirstOrDefaultAsync() ?? throw new NotFoundException("PC not found");
    }

    public async Task<PCResponse> AddAsync(CreatePCRequest req, CancellationToken cancellationToken)
    {
        var pc = new PCs
        {
            Name = req.Name,
            Weight = req.Weight,
            Warranty = req.Warranty,
            CreatedAt = req.CreatedAt,
            Stock = req.Stock
        };

        ctx.Add(pc);
        await ctx.SaveChangesAsync(cancellationToken);
        return new PCResponse(pc.Id, pc.Name, pc.Weight, pc.Warranty, pc.CreatedAt, pc.Stock);
    }

    public async Task UpdateAsync(int id, UpdatePCRequest req, CancellationToken cancellationToken)
    {
        var pc = await ctx.PCs.FirstOrDefaultAsync(pc => pc.Id == id, cancellationToken);
        if (pc == null)
        {
            throw new NotFoundException("PC not found");
        }
        pc.Name = req.Name;
        pc.Weight = req.Weight;
        pc.Warranty = req.Warranty;
        pc.CreatedAt = DateTime.Now;
        pc.Stock = req.Stock;
        await ctx.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var pc = await ctx.PCs.FirstOrDefaultAsync(pc => pc.Id == id, cancellationToken);
        if (pc == null)
        {
            throw new NotFoundException("PC not found");
        }
        ctx.Remove(pc);
        await ctx.SaveChangesAsync(cancellationToken);
    }
}