import 'dart:math' as Math;

import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';

import '../../../styles/colours.dart';
import 'content_card.dart';

SliverPersistentHeader paintHeaderCard(String headerText) {
  return SliverPersistentHeader(
    pinned: true,
    delegate: _SliverHeaderDelegate(
      minHeight: 50.0,
      maxHeight: 75.0,
      child: ContentCard(
        child: Center(
          child: Text(
            headerText,
            textAlign: TextAlign.end,
            style: GoogleFonts.montserrat(
              fontSize: 20,
              fontWeight: FontWeight.bold,
              color: primaryTextColour,
            ),
          ),
        ),
      ),
    ),
  );
}

class _SliverHeaderDelegate extends SliverPersistentHeaderDelegate {
  _SliverHeaderDelegate({
    required this.minHeight,
    required this.maxHeight,
    required this.child,
  });
  final double minHeight;
  final double maxHeight;
  final Widget child;
  @override
  double get minExtent => minHeight;
  @override
  double get maxExtent => Math.max(maxHeight, minHeight);
  @override
  Widget build(
    BuildContext context,
    double shrinkOffset,
    bool overlapsContent,
  ) {
    return SizedBox.expand(child: child);
  }

  @override
  bool shouldRebuild(_SliverHeaderDelegate oldDelegate) {
    return maxHeight != oldDelegate.maxHeight ||
        minHeight != oldDelegate.minHeight ||
        child != oldDelegate.child;
  }
}
