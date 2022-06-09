using System;

using Microsoft.CodeAnalysis;


namespace R5T.T0126
{
    public class SyntaxTokenAnnotation : TypedSyntaxAnnotation<SyntaxToken>, ISyntaxTokenAnnotation
    {
        #region Static

        public static ISyntaxTokenAnnotation Initialize()
        {
            return null;
        }
        
        public static SyntaxTokenAnnotation From(SyntaxAnnotation annotation)
        {
            var output = new SyntaxTokenAnnotation(annotation);
            return output;
        }

        #endregion


        public SyntaxTokenAnnotation(SyntaxAnnotation annotation)
            : base(annotation)
        {
        }
    }
}
