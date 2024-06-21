using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IramImmo.Model
{
    // la classe implemente inotify 
    public class BienImmobilier : INotifyPropertyChanged
    {
        private const double PCT_COMMISSION = 5.0;
        private const double PRIX_MIN = 5000.0;


        //Champ 
        private string _proprioName;
        private double _prixNet;
        private double _commission;
        private double _prixDeVente;

        //
        public event PropertyChangedEventHandler? PropertyChanged;

        //
        public BienImmobilier(string proprioName, double prixNet)
        {
            ProprioName = proprioName;
            PrixNet = prixNet;
            CalculCommision();
            CalculPrixDeVente();
        }
        public string ProprioName
        {
            get => _proprioName;
            set
            {
                _proprioName = value;
            }
        }

        // Mettere le fonction dans prix net car ils utilisent  prix net dans leur calcule 
        public double PrixNet
        {
            get => _prixNet;
            set
            {
                if (value >= PRIX_MIN)
                    _prixNet = value;
                CalculCommision();
                CalculPrixDeVente();
            }
        }

        // mettre on propoerty changed suelment a l'endroit que doit recevoir la notif de changement 
        public double Commission
        {
            get => _commission;
            set
            {
                _commission = value;
                OnPropertyChanged(nameof(Commission));

            }
        }
        public double PrixDeVente
        {
            get => _prixDeVente;
            set
            {
                _prixDeVente = value;
                OnPropertyChanged(nameof(PrixDeVente));
            }
        }
        public virtual string BienProprio => _proprioName;


        public void CalculPrixDeVente()
        {
            PrixDeVente = PrixNet + Commission;
        }
        public virtual void CalculCommision()
        {
            Commission = PrixNet * PCT_COMMISSION / 100.0;
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }



}
