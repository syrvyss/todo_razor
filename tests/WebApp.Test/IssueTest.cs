using System;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http.HttpResults;
using WebApp.Data.Interfaces;
using WebApp.Models;

using Xunit;

namespace WebApp.Test {
    public class IssueTest {
        [Fact]
        public void IsCorrectDate() {
            // Arrange
            Issue issue = new() {
                Status = Status.Todo,
                Priority = Priority.Low
            };

            // Act
            int dayOfYear = issue.Created.Value.DayOfYear;

            // Assert
            Assert.Equal(dayOfYear, issue.Created.Value.DayOfYear);
        }

        [Fact]
        public void IsCorrectId() {
            // Arrange
            List<Issue> issues = new();

            // Act
            for (int i = 0; i < 255; i++) {
                Issue temp = new() {
                    Status = Status.Doing,
                    Priority = Priority.Normal
                };
                
                issues.Add(temp);
            }

            // Assert
            Assert.True(!issues.Distinct().Any());
        }
    }
}