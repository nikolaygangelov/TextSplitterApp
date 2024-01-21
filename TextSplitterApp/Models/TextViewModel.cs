using System.ComponentModel.DataAnnotations;

namespace TextSplitterApp.Models
{
	/// <summary>
	/// substitute of database
	/// </summary>
	public class TextViewModel
	{
		/// <summary>
		/// adding some validations using attributes
		/// </summary>
		[Required]
		[MaxLength(30)]
		[MinLength(2)]
		public string Text { get; set; }
		public string SplitText { get; set; }
	}
}
