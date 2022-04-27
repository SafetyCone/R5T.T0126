using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis;

using R5T.T0126;


namespace System
{
    public static partial class SyntaxNodeExtensions
    {
        public static TNode Annotate_Typed<TNode>(this TNode node,
            out SyntaxNodeAnnotation<TNode> annotation)
            where TNode : SyntaxNode
        {
            var output = node.Annotate(out SyntaxAnnotation untypedAnnotation);

            annotation = SyntaxNodeAnnotation.From<TNode>(untypedAnnotation);

            return output;
        }

        public static TRootNode AnnotateNode_Typed<TRootNode, TNode>(this TRootNode rootNode,
            TNode node,
            out SyntaxNodeAnnotation<TNode> annotation)
            where TRootNode : SyntaxNode
            where TNode : SyntaxNode
        {
            var output = rootNode.AnnotateNode(
                node,
                out SyntaxAnnotation untypedAnnotation);

            annotation = SyntaxNodeAnnotation.From<TNode>(untypedAnnotation);

            return output;
        }

        public static TNode AnnotateNodes_Typed<TNode, TDescendantNode>(this TNode node,
            IEnumerable<TDescendantNode> descendantNodes,
            out Dictionary<TDescendantNode, SyntaxNodeAnnotation<TDescendantNode>> annotationsByInputNode)
            where TNode : SyntaxNode
            where TDescendantNode : SyntaxNode
        {
            var outputNode = node.AnnotateNodes(
                descendantNodes,
                out var untypedAnnotationsByInputNode);

            annotationsByInputNode = untypedAnnotationsByInputNode.ToTypedAnnotationsByNode();

            return outputNode;
        }

        public static TNode AnnotateNodes_Typed<TNode, TDescendantNode, TTypedSyntaxAnnotation>(this TNode node,
            IEnumerable<TDescendantNode> descendantNodes,
            Func<SyntaxAnnotation, TTypedSyntaxAnnotation> typedSyntaxAnnotationConstructor,
            out Dictionary<TDescendantNode, TTypedSyntaxAnnotation> annotationsByInputNode)
            where TNode : SyntaxNode
            where TDescendantNode : SyntaxNode
            where TTypedSyntaxAnnotation : SyntaxNodeAnnotation<TDescendantNode>
        {
            var outputNode = node.AnnotateNodes(
                descendantNodes,
                out var untypedAnnotationsByInputNode);

            annotationsByInputNode = untypedAnnotationsByInputNode.ToTypedAnnotationsByNode(
                typedSyntaxAnnotationConstructor);

            return outputNode;
        }

        public static TOut Get<TRootNode, TNode, TOut>(this TRootNode rootNode,
            ISyntaxNodeAnnotation<TNode> annotation,
            Func<TNode, TOut> selector)
            where TRootNode : SyntaxNode
            where TNode : SyntaxNode
        {
            var node = rootNode.GetAnnotatedNode_Typed(annotation);

            var output = selector(node);
            return output;
        }

        public static TNode GetAnnotatedNode_Typed<TRootNode, TNode>(this TRootNode rootNode,
            ISyntaxNodeAnnotation<TNode> annotation)
            where TRootNode : SyntaxNode
            where TNode : SyntaxNode
        {
            var node = rootNode.GetAnnotatedNode(annotation.SyntaxAnnotation) as TNode;
            return node;
        }

        public static Dictionary<ISyntaxNodeAnnotation<TNode>, TNode> GetAnnotatedNodes_Typed<TRootNode, TNode>(this TRootNode rootNode,
            IEnumerable<ISyntaxNodeAnnotation<TNode>> annotations)
            where TRootNode : SyntaxNode
            where TNode : SyntaxNode
        {
            var output = annotations
                .Select(x => new { Annotation = x, Node = rootNode.GetAnnotatedNode_Typed(x) })
                .ToDictionary(
                    x => x.Annotation,
                    x => x.Node);

            return output;
        }

        public static async Task<TRootNode> Modify_Typed<TRootNode, TNode>(this TRootNode rootNode,
            SyntaxNodeAnnotation<TNode> annotation,
            Func<TNode, Task<TNode>> nodeModificationAction)
            where TRootNode : SyntaxNode
            where TNode : SyntaxNode
        {
            var node = rootNode.GetAnnotatedNode_Typed(annotation);

            var modifiedNode = await nodeModificationAction(node);

            var outputCompilationUnit = rootNode.ReplaceNode_Better(node, modifiedNode);
            return outputCompilationUnit;
        }

        public static TRootNode Modify_TypedSynchronous<TRootNode, TNode>(this TRootNode rootNode,
            SyntaxNodeAnnotation<TNode> annotation,
            Func<TNode, TNode> nodeModificationAction)
            where TRootNode : SyntaxNode
            where TNode : SyntaxNode
        {
            var node = rootNode.GetAnnotatedNode_Typed(annotation);

            var modifiedNode = nodeModificationAction(node);

            var outputCompilationUnit = rootNode.ReplaceNode_Better(node, modifiedNode);
            return outputCompilationUnit;
        }
    }
}
