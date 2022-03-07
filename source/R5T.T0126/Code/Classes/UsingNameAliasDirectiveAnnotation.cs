using System;

using Microsoft.CodeAnalysis;


namespace R5T.T0126
{
    public class UsingNameAliasDirectiveAnnotation : UsingDirectiveAnnotation
    {
        #region Static

        public static new UsingNameAliasDirectiveAnnotation From(SyntaxAnnotation annotation)
        {
            var output = new UsingNameAliasDirectiveAnnotation(annotation);
            return output;
        }

        public static UsingNameAliasDirectiveAnnotation From(UsingDirectiveAnnotation annotation)
        {
            var output = new UsingNameAliasDirectiveAnnotation(annotation.SyntaxAnnotation);
            return output;
        }

        #endregion


        public UsingNameAliasDirectiveAnnotation(SyntaxAnnotation annotation)
            : base(annotation)
        {
        }
    }
}
