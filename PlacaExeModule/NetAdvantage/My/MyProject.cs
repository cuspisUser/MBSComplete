namespace My
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.ApplicationServices;
    using Microsoft.VisualBasic.CompilerServices;
    using Microsoft.VisualBasic.MyServices.Internal;
    using Obracun;
    using RadnikExtension;
    using RSM;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Diagnostics;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    [StandardModule, GeneratedCode("MyTemplate", "8.0.0.0"), HideModuleName]
    internal sealed class MyProject
    {
        private static readonly ThreadSafeObjectProvider<MyApplication> m_AppObjectProvider = new ThreadSafeObjectProvider<MyApplication>();
        private static readonly ThreadSafeObjectProvider<MyComputer> m_ComputerObjectProvider = new ThreadSafeObjectProvider<MyComputer>();
        private static ThreadSafeObjectProvider<MyForms> m_MyFormsObjectProvider = new ThreadSafeObjectProvider<MyForms>();
        private static readonly ThreadSafeObjectProvider<MyWebServices> m_MyWebServicesObjectProvider = new ThreadSafeObjectProvider<MyWebServices>();
        private static readonly ThreadSafeObjectProvider<Microsoft.VisualBasic.ApplicationServices.User> m_UserObjectProvider = new ThreadSafeObjectProvider<Microsoft.VisualBasic.ApplicationServices.User>();

        [HelpKeyword("My.Application")]
        internal static MyApplication Application
        {
            [DebuggerHidden]
            get
            {
                return m_AppObjectProvider.GetInstance;
            }
        }

        [HelpKeyword("My.Computer")]
        internal static MyComputer Computer
        {
            [DebuggerHidden]
            get
            {
                return m_ComputerObjectProvider.GetInstance;
            }
        }

        [HelpKeyword("My.Forms")]
        internal static MyForms Forms
        {
            [DebuggerHidden]
            get
            {
                return m_MyFormsObjectProvider.GetInstance;
            }
        }

        [HelpKeyword("My.User")]
        internal static Microsoft.VisualBasic.ApplicationServices.User User
        {
            [DebuggerHidden]
            get
            {
                return m_UserObjectProvider.GetInstance;
            }
        }

        [HelpKeyword("My.WebServices")]
        internal static MyWebServices WebServices
        {
            [DebuggerHidden]
            get
            {
                return m_MyWebServicesObjectProvider.GetInstance;
            }
        }

        [MyGroupCollection("System.Windows.Forms.Form", "Create__Instance__", "Dispose__Instance__", "My.MyProject.Forms"), EditorBrowsable(EditorBrowsableState.Never)]
        internal sealed class MyForms
        {
            public AboutBox1 m_AboutBox1;
            public fmProgress m_fmProgress;
            [ThreadStatic]
            private static Hashtable m_FormBeingCreated;
            public FrmBrojIDatum m_FrmBrojIDatum;
            public FrmBrojIDatumzAaMORTIZACIJU m_FrmBrojIDatumzAaMORTIZACIJU;
            public Obracun.frmEleBrisiSvi m_frmEleBrisiSvi;
            public Obracun.frmEleUnos m_frmEleUnos;
            public Obracun.frmEleUnosSvi m_frmEleUnosSvi;
            public RSM.frmIdentifikator m_frmIdentifikator;
            public frmIspravak m_frmIspravak;
            public frmIznosi m_frmIznosi;
            public frmIznosiSmanjenje m_frmIznosiSmanjenje;
            public frmKolicina m_frmKolicina;
            public frmKonacni m_frmKonacni;
            public frmOdabirPostojece m_frmOdabirPostojece;
            public frmOdabirZaIspisPlatne m_frmOdabirZaIspisPlatne;
            public frmPreglediGodina m_frmPreglediGodina;
            public frmPreglediGodinaObracuna m_frmPreglediGodinaObracuna;
            public frmPregledIzvjestaja m_frmPregledIzvjestaja;
            public frmPregledMjeseciGodina m_frmPregledMjeseciGodina;
            public frmPregledMjeseciGodinaObracuna m_frmPregledMjeseciGodinaObracuna;
            public frmPregledObracuna m_frmPregledObracuna;
            public frmPregledRadnika m_frmPregledRadnika;
            public frmPregledZaRashod m_frmPregledZaRashod;
            public frmRadSaBankama m_frmRadSaBankama;
            public frmStatus m_frmStatus;
            public frmUnosPodatakaOObracunu m_frmUnosPodatakaOObracunu;
            public frmUvjetiBilanca m_frmUvjetiBilanca;
            public RadnikExtension.frmUvjetiEvidencijaRadnika m_frmUvjetiEvidencijaRadnika;
            public frmUvjetiInventurnaLista m_frmUvjetiInventurnaLista;

            [DebuggerHidden]
            private static T Create__Instance__<T>(T Instance) where T: Form, new()
            {
                T local;
                if ((Instance != null) && !Instance.IsDisposed)
                {
                    return Instance;
                }
                if (m_FormBeingCreated != null)
                {
                    if (m_FormBeingCreated.ContainsKey(typeof(T)))
                    {
                        throw new InvalidOperationException(Utils.GetResourceString("WinForms_RecursiveFormCreate", new string[0]));
                    }
                }
                else
                {
                    m_FormBeingCreated = new Hashtable();
                }
                m_FormBeingCreated.Add(typeof(T), null);
                try
                {
                    local = Activator.CreateInstance<T>();
                }
                catch(Exception exception)
                {
                    throw new InvalidOperationException(Utils.GetResourceString("WinForms_SeeInnerException", new string[] { exception.InnerException.Message }), exception.InnerException);
                }
                finally
                {
                    m_FormBeingCreated.Remove(typeof(T));
                }
                return local;
            }

            [DebuggerHidden]
            private void Dispose__Instance__<T>(ref T instance) where T: Form
            {
                instance.Dispose();
                instance = default(T);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public override bool Equals(object o)
            {
                return base.Equals(RuntimeHelpers.GetObjectValue(o));
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            internal new Type GetType()
            {
                return typeof(MyProject.MyForms);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public override string ToString()
            {
                return base.ToString();
            }

            public AboutBox1 AboutBox1
            {
                [DebuggerNonUserCode]
                get
                {
                    this.m_AboutBox1 = Create__Instance__<AboutBox1>(this.m_AboutBox1);
                    return this.m_AboutBox1;
                }
                [DebuggerNonUserCode]
                set
                {
                    if (value != this.m_AboutBox1)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<AboutBox1>(ref this.m_AboutBox1);
                    }
                }
            }

            public fmProgress fmProgress
            {
                [DebuggerNonUserCode]
                get
                {
                    this.m_fmProgress = Create__Instance__<fmProgress>(this.m_fmProgress);
                    return this.m_fmProgress;
                }
                [DebuggerNonUserCode]
                set
                {
                    if (value != this.m_fmProgress)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<fmProgress>(ref this.m_fmProgress);
                    }
                }
            }

            public FrmBrojIDatum FrmBrojIDatum
            {
                [DebuggerNonUserCode]
                get
                {
                    this.m_FrmBrojIDatum = Create__Instance__<FrmBrojIDatum>(this.m_FrmBrojIDatum);
                    return this.m_FrmBrojIDatum;
                }
                [DebuggerNonUserCode]
                set
                {
                    if (value != this.m_FrmBrojIDatum)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<FrmBrojIDatum>(ref this.m_FrmBrojIDatum);
                    }
                }
            }

            public FrmBrojIDatumzAaMORTIZACIJU FrmBrojIDatumzAaMORTIZACIJU
            {
                [DebuggerNonUserCode]
                get
                {
                    this.m_FrmBrojIDatumzAaMORTIZACIJU = Create__Instance__<FrmBrojIDatumzAaMORTIZACIJU>(this.m_FrmBrojIDatumzAaMORTIZACIJU);
                    return this.m_FrmBrojIDatumzAaMORTIZACIJU;
                }
                [DebuggerNonUserCode]
                set
                {
                    if (value != this.m_FrmBrojIDatumzAaMORTIZACIJU)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<FrmBrojIDatumzAaMORTIZACIJU>(ref this.m_FrmBrojIDatumzAaMORTIZACIJU);
                    }
                }
            }

            public Obracun.frmEleBrisiSvi frmEleBrisiSvi
            {
                [DebuggerNonUserCode]
                get
                {
                    this.m_frmEleBrisiSvi = Create__Instance__<Obracun.frmEleBrisiSvi>(this.m_frmEleBrisiSvi);
                    return this.m_frmEleBrisiSvi;
                }
                [DebuggerNonUserCode]
                set
                {
                    if (value != this.m_frmEleBrisiSvi)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<Obracun.frmEleBrisiSvi>(ref this.m_frmEleBrisiSvi);
                    }
                }
            }

            public Obracun.frmEleUnos frmEleUnos
            {
                [DebuggerNonUserCode]
                get
                {
                    this.m_frmEleUnos = Create__Instance__<Obracun.frmEleUnos>(this.m_frmEleUnos);
                    return this.m_frmEleUnos;
                }
                [DebuggerNonUserCode]
                set
                {
                    if (value != this.m_frmEleUnos)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<Obracun.frmEleUnos>(ref this.m_frmEleUnos);
                    }
                }
            }

            public Obracun.frmEleUnosSvi frmEleUnosSvi
            {
                [DebuggerNonUserCode]
                get
                {
                    this.m_frmEleUnosSvi = Create__Instance__<Obracun.frmEleUnosSvi>(this.m_frmEleUnosSvi);
                    return this.m_frmEleUnosSvi;
                }
                [DebuggerNonUserCode]
                set
                {
                    if (value != this.m_frmEleUnosSvi)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<Obracun.frmEleUnosSvi>(ref this.m_frmEleUnosSvi);
                    }
                }
            }

            public RSM.frmIdentifikator frmIdentifikator
            {
                [DebuggerNonUserCode]
                get
                {
                    this.m_frmIdentifikator = Create__Instance__<RSM.frmIdentifikator>(this.m_frmIdentifikator);
                    return this.m_frmIdentifikator;
                }
                [DebuggerNonUserCode]
                set
                {
                    if (value != this.m_frmIdentifikator)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<RSM.frmIdentifikator>(ref this.m_frmIdentifikator);
                    }
                }
            }

            public frmIspravak frmIspravak
            {
                [DebuggerNonUserCode]
                get
                {
                    this.m_frmIspravak = Create__Instance__<frmIspravak>(this.m_frmIspravak);
                    return this.m_frmIspravak;
                }
                [DebuggerNonUserCode]
                set
                {
                    if (value != this.m_frmIspravak)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<frmIspravak>(ref this.m_frmIspravak);
                    }
                }
            }

            public frmIznosi frmIznosi
            {
                [DebuggerNonUserCode]
                get
                {
                    this.m_frmIznosi = Create__Instance__<frmIznosi>(this.m_frmIznosi);
                    return this.m_frmIznosi;
                }
                [DebuggerNonUserCode]
                set
                {
                    if (value != this.m_frmIznosi)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<frmIznosi>(ref this.m_frmIznosi);
                    }
                }
            }

            public frmIznosiSmanjenje frmIznosiSmanjenje
            {
                [DebuggerNonUserCode]
                get
                {
                    this.m_frmIznosiSmanjenje = Create__Instance__<frmIznosiSmanjenje>(this.m_frmIznosiSmanjenje);
                    return this.m_frmIznosiSmanjenje;
                }
                [DebuggerNonUserCode]
                set
                {
                    if (value != this.m_frmIznosiSmanjenje)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<frmIznosiSmanjenje>(ref this.m_frmIznosiSmanjenje);
                    }
                }
            }

            public frmKolicina frmKolicina
            {
                [DebuggerNonUserCode]
                get
                {
                    this.m_frmKolicina = Create__Instance__<frmKolicina>(this.m_frmKolicina);
                    return this.m_frmKolicina;
                }
                [DebuggerNonUserCode]
                set
                {
                    if (value != this.m_frmKolicina)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<frmKolicina>(ref this.m_frmKolicina);
                    }
                }
            }

            public frmKonacni frmKonacni
            {
                [DebuggerNonUserCode]
                get
                {
                    this.m_frmKonacni = Create__Instance__<frmKonacni>(this.m_frmKonacni);
                    return this.m_frmKonacni;
                }
                [DebuggerNonUserCode]
                set
                {
                    if (value != this.m_frmKonacni)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<frmKonacni>(ref this.m_frmKonacni);
                    }
                }
            }

            public frmOdabirPostojece frmOdabirPostojece
            {
                [DebuggerNonUserCode]
                get
                {
                    this.m_frmOdabirPostojece = Create__Instance__<frmOdabirPostojece>(this.m_frmOdabirPostojece);
                    return this.m_frmOdabirPostojece;
                }
                [DebuggerNonUserCode]
                set
                {
                    if (value != this.m_frmOdabirPostojece)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<frmOdabirPostojece>(ref this.m_frmOdabirPostojece);
                    }
                }
            }

            public frmOdabirZaIspisPlatne frmOdabirZaIspisPlatne
            {
                [DebuggerNonUserCode]
                get
                {
                    this.m_frmOdabirZaIspisPlatne = Create__Instance__<frmOdabirZaIspisPlatne>(this.m_frmOdabirZaIspisPlatne);
                    return this.m_frmOdabirZaIspisPlatne;
                }
                [DebuggerNonUserCode]
                set
                {
                    if (value != this.m_frmOdabirZaIspisPlatne)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<frmOdabirZaIspisPlatne>(ref this.m_frmOdabirZaIspisPlatne);
                    }
                }
            }

            public frmPreglediGodina frmPreglediGodina
            {
                [DebuggerNonUserCode]
                get
                {
                    this.m_frmPreglediGodina = Create__Instance__<frmPreglediGodina>(this.m_frmPreglediGodina);
                    return this.m_frmPreglediGodina;
                }
                [DebuggerNonUserCode]
                set
                {
                    if (value != this.m_frmPreglediGodina)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<frmPreglediGodina>(ref this.m_frmPreglediGodina);
                    }
                }
            }

            public frmPreglediGodinaObracuna frmPreglediGodinaObracuna
            {
                [DebuggerNonUserCode]
                get
                {
                    this.m_frmPreglediGodinaObracuna = Create__Instance__<frmPreglediGodinaObracuna>(this.m_frmPreglediGodinaObracuna);
                    return this.m_frmPreglediGodinaObracuna;
                }
                [DebuggerNonUserCode]
                set
                {
                    if (value != this.m_frmPreglediGodinaObracuna)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<frmPreglediGodinaObracuna>(ref this.m_frmPreglediGodinaObracuna);
                    }
                }
            }

            public frmPregledIzvjestaja frmPregledIzvjestaja
            {
                [DebuggerNonUserCode]
                get
                {
                    this.m_frmPregledIzvjestaja = Create__Instance__<frmPregledIzvjestaja>(this.m_frmPregledIzvjestaja);
                    return this.m_frmPregledIzvjestaja;
                }
                [DebuggerNonUserCode]
                set
                {
                    if (value != this.m_frmPregledIzvjestaja)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<frmPregledIzvjestaja>(ref this.m_frmPregledIzvjestaja);
                    }
                }
            }

            public frmPregledMjeseciGodina frmPregledMjeseciGodina
            {
                [DebuggerNonUserCode]
                get
                {
                    this.m_frmPregledMjeseciGodina = Create__Instance__<frmPregledMjeseciGodina>(this.m_frmPregledMjeseciGodina);
                    return this.m_frmPregledMjeseciGodina;
                }
                [DebuggerNonUserCode]
                set
                {
                    if (value != this.m_frmPregledMjeseciGodina)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<frmPregledMjeseciGodina>(ref this.m_frmPregledMjeseciGodina);
                    }
                }
            }

            public frmPregledMjeseciGodinaObracuna frmPregledMjeseciGodinaObracuna
            {
                [DebuggerNonUserCode]
                get
                {
                    this.m_frmPregledMjeseciGodinaObracuna = Create__Instance__<frmPregledMjeseciGodinaObracuna>(this.m_frmPregledMjeseciGodinaObracuna);
                    return this.m_frmPregledMjeseciGodinaObracuna;
                }
                [DebuggerNonUserCode]
                set
                {
                    if (value != this.m_frmPregledMjeseciGodinaObracuna)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<frmPregledMjeseciGodinaObracuna>(ref this.m_frmPregledMjeseciGodinaObracuna);
                    }
                }
            }

            public frmPregledObracuna frmPregledObracuna
            {
                [DebuggerNonUserCode]
                get
                {
                    this.m_frmPregledObracuna = Create__Instance__<frmPregledObracuna>(this.m_frmPregledObracuna);
                    return this.m_frmPregledObracuna;
                }
                [DebuggerNonUserCode]
                set
                {
                    if (value != this.m_frmPregledObracuna)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<frmPregledObracuna>(ref this.m_frmPregledObracuna);
                    }
                }
            }

            public frmPregledRadnika frmPregledRadnika
            {
                [DebuggerNonUserCode]
                get
                {
                    this.m_frmPregledRadnika = Create__Instance__<frmPregledRadnika>(this.m_frmPregledRadnika);
                    return this.m_frmPregledRadnika;
                }
                [DebuggerNonUserCode]
                set
                {
                    if (value != this.m_frmPregledRadnika)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<frmPregledRadnika>(ref this.m_frmPregledRadnika);
                    }
                }
            }

            public frmPregledZaRashod frmPregledZaRashod
            {
                [DebuggerNonUserCode]
                get
                {
                    this.m_frmPregledZaRashod = Create__Instance__<frmPregledZaRashod>(this.m_frmPregledZaRashod);
                    return this.m_frmPregledZaRashod;
                }
                [DebuggerNonUserCode]
                set
                {
                    if (value != this.m_frmPregledZaRashod)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<frmPregledZaRashod>(ref this.m_frmPregledZaRashod);
                    }
                }
            }

            public frmRadSaBankama frmRadSaBankama
            {
                [DebuggerNonUserCode]
                get
                {
                    this.m_frmRadSaBankama = Create__Instance__<frmRadSaBankama>(this.m_frmRadSaBankama);
                    return this.m_frmRadSaBankama;
                }
                [DebuggerNonUserCode]
                set
                {
                    if (value != this.m_frmRadSaBankama)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<frmRadSaBankama>(ref this.m_frmRadSaBankama);
                    }
                }
            }

            public frmStatus frmStatus
            {
                [DebuggerNonUserCode]
                get
                {
                    this.m_frmStatus = Create__Instance__<frmStatus>(this.m_frmStatus);
                    return this.m_frmStatus;
                }
                [DebuggerNonUserCode]
                set
                {
                    if (value != this.m_frmStatus)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<frmStatus>(ref this.m_frmStatus);
                    }
                }
            }

            public frmUnosPodatakaOObracunu frmUnosPodatakaOObracunu
            {
                [DebuggerNonUserCode]
                get
                {
                    this.m_frmUnosPodatakaOObracunu = Create__Instance__<frmUnosPodatakaOObracunu>(this.m_frmUnosPodatakaOObracunu);
                    return this.m_frmUnosPodatakaOObracunu;
                }
                [DebuggerNonUserCode]
                set
                {
                    if (value != this.m_frmUnosPodatakaOObracunu)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<frmUnosPodatakaOObracunu>(ref this.m_frmUnosPodatakaOObracunu);
                    }
                }
            }

            public frmUvjetiBilanca frmUvjetiBilanca
            {
                [DebuggerNonUserCode]
                get
                {
                    this.m_frmUvjetiBilanca = Create__Instance__<frmUvjetiBilanca>(this.m_frmUvjetiBilanca);
                    return this.m_frmUvjetiBilanca;
                }
                [DebuggerNonUserCode]
                set
                {
                    if (value != this.m_frmUvjetiBilanca)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<frmUvjetiBilanca>(ref this.m_frmUvjetiBilanca);
                    }
                }
            }

            public RadnikExtension.frmUvjetiEvidencijaRadnika frmUvjetiEvidencijaRadnika
            {
                [DebuggerNonUserCode]
                get
                {
                    this.m_frmUvjetiEvidencijaRadnika = Create__Instance__<RadnikExtension.frmUvjetiEvidencijaRadnika>(this.m_frmUvjetiEvidencijaRadnika);
                    return this.m_frmUvjetiEvidencijaRadnika;
                }
                [DebuggerNonUserCode]
                set
                {
                    if (value != this.m_frmUvjetiEvidencijaRadnika)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<RadnikExtension.frmUvjetiEvidencijaRadnika>(ref this.m_frmUvjetiEvidencijaRadnika);
                    }
                }
            }

            public frmUvjetiInventurnaLista frmUvjetiInventurnaLista
            {
                [DebuggerNonUserCode]
                get
                {
                    this.m_frmUvjetiInventurnaLista = Create__Instance__<frmUvjetiInventurnaLista>(this.m_frmUvjetiInventurnaLista);
                    return this.m_frmUvjetiInventurnaLista;
                }
                [DebuggerNonUserCode]
                set
                {
                    if (value != this.m_frmUvjetiInventurnaLista)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<frmUvjetiInventurnaLista>(ref this.m_frmUvjetiInventurnaLista);
                    }
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", "")]
        internal sealed class MyWebServices
        {
            [DebuggerHidden]
            private static T Create__Instance__<T>(T instance) where T: new()
            {
                if (instance == null)
                {
                    return Activator.CreateInstance<T>();
                }
                return instance;
            }

            [DebuggerHidden]
            private void Dispose__Instance__<T>(ref T instance)
            {
                instance = default(T);
            }

            [DebuggerHidden, EditorBrowsable(EditorBrowsableState.Never)]
            public override bool Equals(object o)
            {
                return base.Equals(RuntimeHelpers.GetObjectValue(o));
            }

            [DebuggerHidden, EditorBrowsable(EditorBrowsableState.Never)]
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            [EditorBrowsable(EditorBrowsableState.Never), DebuggerHidden]
            internal new Type GetType()
            {
                return typeof(MyProject.MyWebServices);
            }

            [DebuggerHidden, EditorBrowsable(EditorBrowsableState.Never)]
            public override string ToString()
            {
                return base.ToString();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), ComVisible(false)]
        internal sealed class ThreadSafeObjectProvider<T> where T: new()
        {
            private readonly ContextValue<T> m_Context;

            [EditorBrowsable(EditorBrowsableState.Never), DebuggerHidden]
            public ThreadSafeObjectProvider()
            {
                this.m_Context = new ContextValue<T>();
            }

            internal T GetInstance
            {
                [DebuggerHidden]
                get
                {
                    T local2 = this.m_Context.Value;
                    if (local2 == null)
                    {
                        local2 = Activator.CreateInstance<T>();
                        this.m_Context.Value = local2;
                    }
                    return local2;
                }
            }
        }
    }
}

