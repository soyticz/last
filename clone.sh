#!/bin/bash

# Navigate to your project directory (update the path accordingly)
cd /workspaces/last || { echo "Directory not found"; exit 1; }

# Check for uncommitted changes
if [[ -n $(git status --porcelain) ]]; then
    echo "Changes detected. Preparing to push..."
    
    # Add all changes to the staging area
    git add .

    # Commit changes with a timestamp
    git commit -m "Auto-commit on $(date '+%Y-%m-%d %H:%M:%S')"

    # Push changes to the specified branch (change 'main' to your branch if needed)
    git push origin master

    echo "Changes have been pushed to the repository."
else
    echo "No changes to commit."
fi
