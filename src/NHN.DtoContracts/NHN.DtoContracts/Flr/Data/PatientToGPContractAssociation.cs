using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using NHN.DtoContracts.Common.en;

namespace NHN.DtoContracts.Flr.Data
{
    /// <summary>
    /// Representerer koblingen mellom en pasient og til en fastlegeliste.
    /// </summary>
    [DataContract(Namespace = FlrXmlNamespace.V1)]
    [Serializable]
    public class PatientToGPContractAssociation
    {
        /// <summary>
        /// Id til denne assiosasjonen. Tilh�righetsId
        /// </summary>
        [DataMember]
        public long Id { get; set; }

        /// <summary>
        /// ID til GPContract. M� v�re satt ved skriving, vil v�re satt ved lesing og vil v�re identisk med GPContract.Id.
        /// </summary>
        [DataMember]
        public long GPContractId { get; set; }

        /// <summary>
        ///  Kontakten denne assoisasjonen peker til. Satt ved lesing, skal v�re null ved skriving.
        /// </summary>
        [DataMember]
        public GPContract GPContract { get; set; }

        /// <summary>
        /// Personnummer til innbygger
        /// </summary>
        [DataMember]
        public string PatientNIN { get; set; }

        /// <summary>
        /// For hvilken periode er denne assiosasjonen gyldig?
        /// For Move metoden s� er FraDato -> fradatoen til nye tilh�righeten, TilDato -> tildatoen til den gamle.
        /// </summary>
        [DataMember]
        public Period Period { get; set; } //FraDato ?TilDato;

        /// <summary>
        /// Kode p� hvorfor perioden er endret (avsluttet). Er NULL normalt sett med mindre personen har forlatt ordningen.
        /// Kodeverk: <see href="/CodeAdmin/EditCodesInGroup/flrv2_endreason">flrv2_endreason</see> (OID 7753).
        /// </summary>
        [DataMember]
        public Code EndCode { get; set; }

        /// <summary>
        /// Kode p� hvorfor perioden er startet.
        /// Kodeverk: <see href="/CodeAdmin/EditCodesInGroup/flrv2_beginreason">flrv2_beginreason</see> (OID 7754).
        /// </summary>
        [DataMember]
        public Code BeginCode { get; set; }

        /// <summary>
        /// Detaljer om pasienten. Dette vil v�re satt p� leseoperasjoner n�r det er relevant, men m� v�re NULL p� skriveoperasjoner.
        /// </summary>
        [DataMember]
        public Person Patient { get; set; }

        /// <summary>
        /// Legeperioder som overlapper med denne pasientperioden p� listen. Dette vil v�re satt p� leseoperasjoner n�r det er relevant, 
        /// men m� v�re NULL p� skriveoperasjoner.
        /// </summary>
        [DataMember]
        public IList<GPOnContractAssociation> DoctorCycles { get; set; }

        /// <summary>
        /// Tidspunkt data ble sist oppdatert
        /// </summary>
        [DataMember]
        public DateTime UpdatedOn { get; set; }
    }
}