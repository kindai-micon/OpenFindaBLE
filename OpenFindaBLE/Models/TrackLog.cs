namespace OpenFindaBLE.Backend.Models
{
	public class TrackLog : BaseEntity
	{
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public double AccelerationX { get; set; }
		public double AccelerationY { get; set; }
		public double AccelerationZ { get; set; }
		public double GyroX { get; set; }
		public double GyroY { get; set; }
		public double GyroZ { get; set; }
		public DateTime ReceiveTime { get; set; }
		public int Reliability { get; set; }
		public Guid DeviceId { get; set; }
	}
}
