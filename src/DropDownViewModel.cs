using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.ExperienceForms.Mvc.Models.Fields;
using System;

namespace SharedSitecore.Forms.Fields.DropDown
{
	[Serializable]
	public class DropDownViewModel : ListViewModel
	{
		public bool ShowEmptyItem { get; set; }
		public bool ShowValues { get; set; }		

		protected override void InitItemProperties(Item item)
		{
			Assert.ArgumentNotNull(item, nameof(item));
			base.InitItemProperties(item);

			ShowEmptyItem = MainUtil.GetBool(item.Fields["Show Empty Item"]?.Value, defaultValue: false);
			ShowValues = MainUtil.GetBool(item.Fields["Show Values"]?.Value, defaultValue: false);          
        }

        protected override void UpdateItemFields(Item item)
		{
			Assert.ArgumentNotNull(item, nameof(item));
			base.UpdateItemFields(item);

			item.Fields["Show Empty Item"]?.SetValue(ShowEmptyItem ? "1" : string.Empty, force: false);
			item.Fields["Show Values"]?.SetValue(ShowValues ? "1" : string.Empty, force: false);
		}
	}
}