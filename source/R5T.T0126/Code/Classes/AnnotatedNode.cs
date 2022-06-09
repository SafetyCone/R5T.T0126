using System;

using Microsoft.CodeAnalysis;


namespace R5T.T0126
{
    public class AnnotatedNode<TNode>
        where TNode : SyntaxNode
    {
        #region Static

        public static implicit operator TNode(AnnotatedNode<TNode> annotatedNode)
        {
            return annotatedNode.Node;
        }

        public static implicit operator SyntaxNodeAnnotation<TNode>(AnnotatedNode<TNode> annotatedNode)
        {
            return annotatedNode;
        }

        // Cannot define conversion operators for interfaces, so implicit conversion to ISyntaxNodeAnnotation<TNode> is out.
        // And the conversion operator for SyntaxNodeAnnotation<TNode> is useless, since C# will not request the implicit conversion to SyntaxNodeAnnotation<TNode> if an ISyntaxNodeAnnotation<TNode> instance is requested.

        #endregion


        public TNode Node { get; }
        public ISyntaxNodeAnnotation<TNode> Annotation { get; }


        public AnnotatedNode(
            TNode node,
            ISyntaxNodeAnnotation<TNode> annotation)
        {
            this.Node = node;
            this.Annotation = annotation;
        }

        public void Deconstruct(out TNode node, out ISyntaxNodeAnnotation<TNode> annotation)
        {
            node = this.Node;
            annotation = this.Annotation;
        }
    }


    public static class AnnotatedNode
    {
        public static AnnotatedNode<TNode> From<TNode>(
            L0011.AnnotatedNode<TNode> untypedAnnotatedNode)
            where TNode : SyntaxNode
        {
            var output = AnnotatedNode.FromUntypedAnnotation(
                untypedAnnotatedNode.Node,
                untypedAnnotatedNode.Annotation);

            return output;
        }

        public static AnnotatedNode<TNode> FromUntypedAnnotation<TNode>(
            TNode node,
            SyntaxAnnotation annotation)
            where TNode : SyntaxNode
        {
            var typedAnnotation = SyntaxNodeAnnotation.From<TNode>(annotation);

            var output = AnnotatedNode.From(
                node,
                typedAnnotation);

            return output;
        }

        public static AnnotatedNode<TNode> From<TNode>(
            TNode node,
            ISyntaxNodeAnnotation<TNode> annotation)
            where TNode : SyntaxNode
        {
            var output = new AnnotatedNode<TNode>(
                node,
                annotation);

            return output;
        }

        public static AnnotatedNode<TNode> From<TNode>(TNode node)
            where TNode : SyntaxNode
        {
            node = node.Annotate_Typed(out var annotation);

            var output = AnnotatedNode.From(
                node,
                annotation);

            return output;
        }
    }
}
