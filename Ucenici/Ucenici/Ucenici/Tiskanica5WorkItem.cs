using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Deklarit.Practices.CompositeUI;
using Deklarit.Practices.CompositeUI.WorkItems;

namespace Ucenici.Ucenici
{
	public class Tiskanica5WorkItem : MdiWorkItemBase
	{
        public Tiskanica5WorkItem(): base("Tiskanica5", new Tiskanica5())
        {

        }

        public override void OnBuiltUp(string id)
        {
            base.OnBuiltUp("");
        }
	}
}
