namespace Int1.Models;

public class Laptop
{
    public string Producer { get; init; } = default!;
    public string? ScreenDiagonal { get; init; }
    public string? ScreenResolution { get; init; }
    public string? ScreenSurface { get; init; }
    public string IsTouchScreen { get; init; } = default!;
    public string? Processor { get; init; }
    public int? PhysicalCores { get; init; }
    public int? ClockSpeed { get; init; }
    public string? MemorySize { get; init; }
    public string? DiskCapacity { get; init; }
    public string? DiskType { get; init; }
    public string? GraphicCard { get; init; }
    public string? GraphicCardMemory { get; init; }
    public string? OperatingSystem { get; init; }
    public string? PhysicalDriveType { get; init; }

    public override string ToString()
    {
        return
            $"{Producer} | {ScreenDiagonal} | {ScreenResolution} | {ScreenSurface} | {IsTouchScreen} | {Processor} | {PhysicalCores} | {ClockSpeed} | {MemorySize} | {DiskCapacity} | {DiskType} | {GraphicCard} | {GraphicCardMemory} | {OperatingSystem} | {PhysicalDriveType}";
    }
}