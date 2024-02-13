using Microsoft.AspNetCore.Mvc;
using AnomalyTrackerBackend.API.Dto;
using AnomalyTrackerBackend.DAL;
using AnomalyTrackerBackend.DAL.Entity;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AnomalyTrackerBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : Controller
    {
        private readonly AnomalyTrackerDbContext _context;
        private readonly IMapper _mapper;

        public AssetController(AnomalyTrackerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetAssetDto>>> GetAssets()
        {
            var assets = await _context.Assets
                .Include(a => a.AssetType)
                .ToListAsync();

            if (assets == null)
            {
                return NotFound();
            }

            return _mapper.Map<List<GetAssetDto>>(assets);
        }

        // Get asset with ID
        [HttpGet("{id}")]
        public async Task<ActionResult<GetAssetDto>> GetAsset(int id)
        {
            var asset = await _context.Assets
                    .Include(a => a.AssetType)
                    .SingleAsync(a => a.Id == id);

            if (asset == null)
            {
                return NotFound();
            }

            return _mapper.Map<GetAssetDto>(asset);
        }

        // Get AssetTypes
        [HttpGet("assettypes")]
        public async Task<ActionResult<List<GetAssetTypeDto>>> GetAssetTypes()
        {
            var assettypes = await _context.AssetTypes.ToListAsync();

            if (assettypes == null)
            {
                return NotFound();
            }

            return _mapper.Map<List<GetAssetTypeDto>>(assettypes);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<GetAssetDto>> UpdateAsset(int id, [FromBody] UpdateAssetDto updateAssetDto)
        {
            var asset = await _context.Assets.FindAsync(id);
            if (asset == null)
            {
                return NotFound();
            }

            asset.IsFlagged = updateAssetDto.IsFlagged;

            _context.Entry(asset).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return _mapper.Map<GetAssetDto>(asset);
        }

        // Filter on asset 
        [HttpGet("filterasset")]
        public async Task<ActionResult<List<GetAssetDto>>> GetFilterAssets(
            string? assetTypes = null,
            string? selectedFlag = null,
            bool assetFlag = false,
            bool selectedAssetDateSorting = true,
            DateTime? selectedStartDate = null,
            DateTime? selectedEndDate = null)
        {

            List<string> assetTypesList = !string.IsNullOrEmpty(assetTypes) ? assetTypes.Split(',').ToList() : null;

            var assets = await _context.Assets
                .Include(a => a.AssetType)
                //.Where(a => a.IsSolved == anomalyStatus)
                //.Where(a => a.IsFlagged == anomalyFlag)
                //.Where(a => a.TimeStamp >= utcStartDateTime && a.TimeStamp <= utcEndDateTime)
                //.Where(a => a.TimeStamp >= selectedStartDate.Value)\
                .OrderByDescending(a => a.AssetType.Name)
                .ToListAsync();

            if (selectedAssetDateSorting)
            {
                assets = assets
                    .OrderByDescending(a => a.TimeStamp)
                    .ToList();
            }
            else
            {
                assets = assets
                    .OrderBy(a => a.TimeStamp)
                    .ToList();
            }

            if (selectedStartDate != null)
            {
                DateTimeOffset utcStartDateTime = TimeZoneInfo.ConvertTimeToUtc((DateTime)selectedStartDate.Value);
                assets = assets
                    .Where(a => a.TimeStamp >= utcStartDateTime)
                    .ToList();
            }

            if (selectedEndDate != null)
            {
                DateTimeOffset utcEndDateTime = TimeZoneInfo.ConvertTimeToUtc((DateTime)selectedEndDate.Value);
                assets = assets
                    .Where(a => a.TimeStamp <= utcEndDateTime.AddDays(1).AddTicks(-1))
                    .ToList();
            }


            if (selectedFlag == "false")
            {
                assets = assets.Where(a => a.IsFlagged == false).ToList();
            }

            if (selectedFlag == "true")
            {
                assets = assets.Where(a => a.IsFlagged == true).ToList();
            }

            if (selectedFlag == "all")
            {
                assets = assets.ToList();
            }

            if (assetTypes != null && assetTypes.Any())
            {
                assets = assets
                    .Where(a => assetTypes.Contains(a.AssetType.Name))
                    .ToList();
            }

            /*if (!selectedSeverity.IsNullOrEmpty())
            {
                if (Enum.TryParse<Severity>(selectedSeverity, out var parsedSeverity))
                {
                    anomalies = anomalies.Where(a => a.AnomalyType.Level == parsedSeverity).ToList();
                }
                else
                {
                    return BadRequest("Invalid severity level");
                }
            }*/

            if (assets == null)
            {
                return NotFound();
            }

            return _mapper.Map<List<GetAssetDto>>(assets);
        }
    }
}
