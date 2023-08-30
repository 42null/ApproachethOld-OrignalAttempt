using System.Collections.Generic;
using UnityEngine;

namespace StaticHelpers
{

    public static class ComponentFinder
    {
        public static List<T> FindComponentsInChildrenWithTag<T>(GameObject parentGameObject, string targetTag) where T : Component
        {
            List<T> foundComponents = new List<T>();
            FindComponentsInChildrenWithTagRecursive(parentGameObject.transform, targetTag, foundComponents);
            return foundComponents;
        }

        private static void FindComponentsInChildrenWithTagRecursive<T>(Transform parent, string targetTag, List<T> foundComponents) where T : Component
        {
            foreach (Transform child in parent)
            {
                if (child.CompareTag(targetTag))
                {
                    T component = child.GetComponent<T>();
                    if (component != null)
                    {
                        foundComponents.Add(component);
                    }
                }

                // Continue searching in the child's children
                FindComponentsInChildrenWithTagRecursive(child, targetTag, foundComponents);
            }
        }
    }

}