using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace SmbComparator
{

	[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.xmlsoap.org/soap/envelope/", IsNullable = false)]
	public partial class Envelope
	{
		public Body Body { get; set; }
	}

	[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.xmlsoap.org/soap/envelope/", IsNullable = false)]
	public partial class Body
	{
		[System.Xml.Serialization.XmlElementAttribute(ElementName = "getViajeFullDetailResponse", Namespace = "http://tempuri.org/", IsNullable = false)]
		public GetViajeFullDetailResponse GetViajeFullDetailResponse { get; set; }
	}

	[System.Xml.Serialization.XmlRootAttribute(ElementName = "getViajeFullDetailResponse", Namespace = "http://tempuri.org/", IsNullable = false)]
	public partial class GetViajeFullDetailResponse
	{
		[System.Xml.Serialization.XmlElementAttribute(ElementName = "getViajeFullDetailResult", IsNullable = false)]
		public GetViajeFullDetailResult GetViajeFullDetailResult { get; set; }
	}

	[System.Xml.Serialization.XmlRootAttribute(ElementName = "getViajeFullDetailResult", Namespace = "http://tempuri.org/", IsNullable = false)]
	public partial class GetViajeFullDetailResult
	{
		[System.Xml.Serialization.XmlElementAttribute(ElementName = "diffgram", Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1", IsNullable = false)]
		public Diffgram Diffgram { get; set; }
	}

	[System.Xml.Serialization.XmlRootAttribute(ElementName = "diffgram", Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1", IsNullable = false)]
	public partial class Diffgram
	{
		[System.Xml.Serialization.XmlElementAttribute(Namespace = "", IsNullable = false)]
		public NewDataSet NewDataSet { get; set; }
	}

	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public partial class NewDataSet
	{
		public Table Table { get; set; }
	}

	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public partial class Table
	{
		public string Salida_Garantizada { get; set; }


		public string Media_Pension { get; set; }


		public int ID_Viaje { get; set; }


		public string Fecha_Inicio_America { get; set; }


		public string Nombre_Viaje { get; set; }


		public string ROTATIVO { get; set; }


		public object Viaje_Incluye { get; set; }


		public string Traslado_Llegada { get; set; }


		public string Traslado_Salida { get; set; }


		public string VIAJE_A_MEDIDA { get; set; }


		public string PARADAS { get; set; }


		public string Confirmacion_Inmediata { get; set; }


		public string Pasajero_Club { get; set; }


		public string NECESARIO_PASAPORTE { get; set; }


		public string TIPOVIAJE { get; set; }


		public string NOMBRE_VIAJE_PORTUGUES { get; set; }


		public string COLOR_VIAJE { get; set; }


		public int TEMPORADA { get; set; }


		public int Numero_Dias { get; set; }


		public string WordEuros { get; set; }


		public string WordDolares { get; set; }


		public object PdfEuros { get; set; }


		public object PdfDolares { get; set; }


		public string WordBrasil { get; set; }


		public object PdfBrasil { get; set; }


		public string PERMITE_COMPARTIR { get; set; }


		public object EXCLUSIVO_BRASIL { get; set; }


		public object EXCLUSIVO_ATOM { get; set; }


		public object VIAJE_OBSERVACIONES { get; set; }


		public int ID_CONSTANTE { get; set; }


		public string TIPO_VIAJE_ESP { get; set; }


		public string COLOR_VIAJE_ESP { get; set; }


		public object PdfEspana { get; set; }


		public string WordEspana { get; set; }


		public string VIAJES_SLOW { get; set; }


		public object URL_IMAGEN { get; set; }


		public string PERMITE_TRIPLE { get; set; }


		public object UrlImagenAlta { get; set; }


		public object UrlImagenEspAlta { get; set; }


		public object UrlImagenBrasilAlta { get; set; }


		public object UrlImagenMedia { get; set; }


		public object UrlImagenEspMedia { get; set; }


		public object UrlImagenBrasilMedia { get; set; }


		public object UrlImagenBaja { get; set; }


		public object UrlImagenEspBaja { get; set; }


		public object UrlImagenBrasilBaja { get; set; }


		public object VIAJE_FOLLETO_PORTUGAL { get; set; }


		public object UrlImagenPortugalAlta { get; set; }


		public object UrlImagenPortugalMedia { get; set; }


		public object UrlImagenPortugalBaja { get; set; }


		public string WordPortugal { get; set; }


		public object PdfPortugal { get; set; }


		public string NombreViajeFolleto { get; set; }


		public string NombreViajeFolletoPortugal { get; set; }


		public string PERMITE_SINGLE { get; set; }


		public string WordEnglish { get; set; }


		public object PdfEnglish { get; set; }


		public string WordEnglishDolares { get; set; }


		public object PdfEnglishDolares { get; set; }


		public string PERMITE_CUADRUPLE { get; set; }


		public object WordRuso { get; set; }


		public object PdfRuso { get; set; }
	}

}
