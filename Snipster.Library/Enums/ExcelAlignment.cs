namespace Snipster.Library.Enums
{
    /// <summary>
    /// Specifies the alignment options for Excel cells.
    /// </summary>
    public enum ExcelAlignment
    {
        /// <summary>
        /// Aligns content to the center of the cell.
        /// </summary>
        Center,

        /// <summary>
        /// Centers content continuously across the cell.
        /// </summary>
        CenterContinuous,

        /// <summary>
        /// Distributes content evenly across the cell.
        /// </summary>
        Distributed,

        /// <summary>
        /// Fills the cell with content by repeating it as necessary.
        /// </summary>
        Fill,

        /// <summary>
        /// General alignment, which lets Excel decide the best alignment based on the content type.
        /// </summary>
        General,

        /// <summary>
        /// Justifies the content within the cell, aligning both left and right edges.
        /// </summary>
        Justify,

        /// <summary>
        /// Aligns content to the left side of the cell.
        /// </summary>
        Left,

        /// <summary>
        /// Aligns content to the right side of the cell.
        /// </summary>
        Right
    }
}
