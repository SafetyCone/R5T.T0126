using System;

using Microsoft.CodeAnalysis;


namespace R5T.T0126
{
    public class SyntaxNodeAnnotation : TypedSyntaxAnnotation, ISyntaxNodeAnnotation
    {
        #region Static

        public static SyntaxNodeAnnotation<TNode> From<TNode>(SyntaxAnnotation annotation)
            where TNode : SyntaxNode
        {
            var output = new SyntaxNodeAnnotation<TNode>(annotation);
            return output;
        }

        public static SyntaxNodeAnnotation<TNode> From<TNode>(TNode _,
            SyntaxAnnotation annotation)
            where TNode : SyntaxNode
        {
            var output = new SyntaxNodeAnnotation<TNode>(annotation);
            return output;
        }

        #endregion


        public SyntaxNodeAnnotation(SyntaxAnnotation annotation)
            : base(annotation)
        {
        }
    }


    public class SyntaxNodeAnnotation<TNode> : TypedSyntaxAnnotation<TNode>, ISyntaxNodeAnnotation<TNode>
        where TNode : SyntaxNode
    {
        public SyntaxNodeAnnotation(SyntaxAnnotation annotation)
            : base(annotation)
        {
        }
    }
}
