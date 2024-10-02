﻿using UnityDebugSheet.Runtime.Core.Scripts;
using UnityEngine;

public sealed class InGameDebugSheetController : MonoBehaviour
{
    private void Start()
    {
        // Get or create the root page.
        var rootPage = DebugSheet.Instance.GetOrCreateInitialPage();

        // Add a link transition to the ExampleDebugPage.
        rootPage.AddPageLinkButton<InGameDebugPage>(nameof(InGameDebugPage));
    }
}