namespace KruegerNationalPark {
	using System;
	using System.Linq;
	using System.Collections.Generic;
	#pragma warning disable 162
	#pragma warning disable 219
	[System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "InconsistentNaming")]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "UnusedParameter.Local")]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "RedundantNameQualifier")]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "PossibleInvalidOperationException")]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "RedundantCheckBeforeAssignment")]
	public class SavannaLayer : Mars.Components.Layers.AbstractLayer {
		private static readonly Mars.Common.Logging.ILogger _Logger = 
					Mars.Common.Logging.LoggerFactory.GetLogger(typeof(SavannaLayer));
		private static readonly Mars.Components.Common.Random _Random = new Mars.Components.Common.Random();
		private double?[] _bbox = new double?[4]; private int? _cellSizeMeters;
		public Mars.Components.Environments.GeoGridHashEnvironment<Tree> _TreeEnvironment { get; set; }
		public KNPGISRasterFenceLayer _KNPGISRasterFenceLayer { get; set; }
		public KNPGISRasterPrecipitationLayer _KNPGISRasterPrecipitationLayer { get; set; }
		public KNPGISRasterShadeLayer _KNPGISRasterShadeLayer { get; set; }
		public KNPGISRasterTempLayer _KNPGISRasterTempLayer { get; set; }
		public KNPGISRasterVegetationLayer _KNPGISRasterVegetationLayer { get; set; }
		public KNPGISVectorWaterLayer _KNPGISVectorWaterLayer { get; set; }
		public System.Collections.Generic.IDictionary<System.Guid, Tree> _TreeAgents { get; set; }
		public SavannaLayer _SavannaLayer => this;
		public SavannaLayer (
		KNPGISRasterFenceLayer _knpgisrasterfencelayer, KNPGISRasterPrecipitationLayer _knpgisrasterprecipitationlayer, KNPGISRasterShadeLayer _knpgisrastershadelayer, KNPGISRasterTempLayer _knpgisrastertemplayer, KNPGISRasterVegetationLayer _knpgisrastervegetationlayer, KNPGISVectorWaterLayer _knpgisvectorwaterlayer, 
		double? topLatitude = null, double? bottomLatitude = null, double? leftLatitude = null, double? rightLatitude = null, int? cellSizeMeters = null) {
			this._KNPGISRasterFenceLayer = _knpgisrasterfencelayer;
			this._KNPGISRasterPrecipitationLayer = _knpgisrasterprecipitationlayer;
			this._KNPGISRasterShadeLayer = _knpgisrastershadelayer;
			this._KNPGISRasterTempLayer = _knpgisrastertemplayer;
			this._KNPGISRasterVegetationLayer = _knpgisrastervegetationlayer;
			this._KNPGISVectorWaterLayer = _knpgisvectorwaterlayer;
			_bbox[0] = topLatitude;_bbox[1] = bottomLatitude;_bbox[2] = leftLatitude;_bbox[3] = rightLatitude;
			_cellSizeMeters = cellSizeMeters;
		}
		
		public override bool InitLayer(
			Mars.Interfaces.Layer.Initialization.TInitData initData, 
			Mars.Interfaces.Layer.RegisterAgent regHandle, 
			Mars.Interfaces.Layer.UnregisterAgent unregHandle)
		{
			if (_bbox.All(d => d.HasValue) && _cellSizeMeters.HasValue) {
				this._TreeEnvironment = Mars.Components.Environments.GeoGridHashEnvironment<Tree>.BuildEnvironment(_bbox[0].Value, _bbox[1].Value, _bbox[2].Value, _bbox[3].Value, _cellSizeMeters.Value);
			} else
			{
				var geometries = new List<GeoAPI.Geometries.IGeometry>();
				var _factory = new NetTopologySuite.Utilities.GeometricShapeFactory();
				_factory.Base = new GeoAPI.Geometries.Coordinate(this._KNPGISRasterFenceLayer.Metadata.LowerLeftBound.Longitude, this._KNPGISRasterFenceLayer.Metadata.LowerLeftBound.Latitude);
				_factory.Height = this._KNPGISRasterFenceLayer.Metadata.CellSizeInDegree * this._KNPGISRasterFenceLayer.Metadata.HeightInGridCells;
				_factory.Width = this._KNPGISRasterFenceLayer.Metadata.CellSizeInDegree * this._KNPGISRasterFenceLayer.Metadata.WidthInGridCells;
				geometries.Add(_factory.CreateRectangle());
				_factory.Base = new GeoAPI.Geometries.Coordinate(this._KNPGISRasterPrecipitationLayer.Metadata.LowerLeftBound.Longitude, this._KNPGISRasterPrecipitationLayer.Metadata.LowerLeftBound.Latitude);
				_factory.Height = this._KNPGISRasterPrecipitationLayer.Metadata.CellSizeInDegree * this._KNPGISRasterPrecipitationLayer.Metadata.HeightInGridCells;
				_factory.Width = this._KNPGISRasterPrecipitationLayer.Metadata.CellSizeInDegree * this._KNPGISRasterPrecipitationLayer.Metadata.WidthInGridCells;
				geometries.Add(_factory.CreateRectangle());
				_factory.Base = new GeoAPI.Geometries.Coordinate(this._KNPGISRasterShadeLayer.Metadata.LowerLeftBound.Longitude, this._KNPGISRasterShadeLayer.Metadata.LowerLeftBound.Latitude);
				_factory.Height = this._KNPGISRasterShadeLayer.Metadata.CellSizeInDegree * this._KNPGISRasterShadeLayer.Metadata.HeightInGridCells;
				_factory.Width = this._KNPGISRasterShadeLayer.Metadata.CellSizeInDegree * this._KNPGISRasterShadeLayer.Metadata.WidthInGridCells;
				geometries.Add(_factory.CreateRectangle());
				_factory.Base = new GeoAPI.Geometries.Coordinate(this._KNPGISRasterTempLayer.Metadata.LowerLeftBound.Longitude, this._KNPGISRasterTempLayer.Metadata.LowerLeftBound.Latitude);
				_factory.Height = this._KNPGISRasterTempLayer.Metadata.CellSizeInDegree * this._KNPGISRasterTempLayer.Metadata.HeightInGridCells;
				_factory.Width = this._KNPGISRasterTempLayer.Metadata.CellSizeInDegree * this._KNPGISRasterTempLayer.Metadata.WidthInGridCells;
				geometries.Add(_factory.CreateRectangle());
				_factory.Base = new GeoAPI.Geometries.Coordinate(this._KNPGISRasterVegetationLayer.Metadata.LowerLeftBound.Longitude, this._KNPGISRasterVegetationLayer.Metadata.LowerLeftBound.Latitude);
				_factory.Height = this._KNPGISRasterVegetationLayer.Metadata.CellSizeInDegree * this._KNPGISRasterVegetationLayer.Metadata.HeightInGridCells;
				_factory.Width = this._KNPGISRasterVegetationLayer.Metadata.CellSizeInDegree * this._KNPGISRasterVegetationLayer.Metadata.WidthInGridCells;
				geometries.Add(_factory.CreateRectangle());
				geometries.AddRange(this._KNPGISVectorWaterLayer.GeometryCollection.Geometries);
				var _feature = new NetTopologySuite.Geometries.GeometryCollection(geometries.ToArray()).Envelope;
				this._TreeEnvironment = Mars.Components.Environments.GeoGridHashEnvironment<Tree>.BuildEnvironment(_feature.Coordinates[1].Y, _feature.Coordinates[0].Y, _feature.Coordinates[0].X, _feature.Coordinates[2].X, _cellSizeMeters ?? 100);
			}
			_TreeAgents = Mars.Components.Services.AgentManager.SpawnAgents<Tree>(
			initData.AgentInitConfigs.First(config => config.Type == typeof(Tree)),
			regHandle, unregHandle, 
			new System.Collections.Generic.List<Mars.Interfaces.Layer.ILayer> { this, this._KNPGISRasterFenceLayer, this._KNPGISRasterPrecipitationLayer, this._KNPGISRasterShadeLayer, this._KNPGISRasterTempLayer, this._KNPGISRasterVegetationLayer, this._KNPGISVectorWaterLayer });
			
			
			return base.InitLayer(initData, regHandle, unregHandle);
		}
		
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public KruegerNationalPark.Tree _SpawnTree(double xcor = 0, double ycor = 0, int freq = 1) {
			var id = System.Guid.NewGuid();
			var agent = new KruegerNationalPark.Tree(id, this, _registerAgent, _unregisterAgent,
			_TreeEnvironment,
			_KNPGISRasterFenceLayer, 
			_KNPGISRasterPrecipitationLayer, 
			_KNPGISRasterShadeLayer, 
			_KNPGISRasterTempLayer, 
			_KNPGISRasterVegetationLayer, 
			_KNPGISVectorWaterLayer
		, 	default(double), 
			default(double), 
			default(double), 
			default(double), 
			default(double), 
			default(double)
		, 	xcor, ycor, freq);
			_TreeAgents.Add(id, agent);
			return agent;
		}
	}
}
