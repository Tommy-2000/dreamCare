import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:flutter_staggered_grid_view/flutter_staggered_grid_view.dart';
import 'package:gap/gap.dart';
import 'package:google_fonts/google_fonts.dart';

import '../../../logic/utils/constants.dart';
import '../../../styles/colours.dart';
import '../../common/buttons/primary_button.dart';
import '../../common/cards/content_card.dart';
import '../../common/cards/chart_cards/stat_card.dart';
import '../../state/common_state.dart';
import '../../state/teamspace_event.dart';
import '../../state/teamspace_state.dart';

class TeamSpaceScreen extends ConsumerStatefulWidget with TeamSpaceState, TeamSpaceEvent {
  const TeamSpaceScreen({super.key});

  @override
  ConsumerState<TeamSpaceScreen> createState() => _TeamSpaceScreenState();
}

class _TeamSpaceScreenState extends ConsumerState<TeamSpaceScreen> {
  @override
  Widget build(BuildContext context) {
    return Container(
      padding: EdgeInsets.all(screenGridPadding),
      child: CustomScrollView(
        slivers: <Widget>[
          SliverToBoxAdapter(
            child: ContentCard(
              child: Text(
                "TeamSpace",
                style: GoogleFonts.montserrat(
                  fontSize: 25,
                  fontWeight: FontWeight.bold,
                  color: primaryTextColour,
                ),
              ),
            ),
          ),
          SliverGap(5),
          SliverToBoxAdapter(
            child: Row(
              mainAxisAlignment: MainAxisAlignment.end,
              children: [
                PrimaryButton(buttonText: "Import Member",
                    buttonIcon: Icon(Icons.cloud_upload_rounded, size: 15.0)),
                Gap(5),
                PrimaryButton(buttonText: "New Member",
                    buttonIcon: Icon(Icons.add_rounded, size: 15.0)),
              ],
            ),),
          SliverGap(5),
          SliverGrid(
            gridDelegate: SliverQuiltedGridDelegate(
              crossAxisCount: 32,
              pattern: [
                QuiltedGridTile(32, 32),
                QuiltedGridTile(16, 16),
                QuiltedGridTile(16, 16),
              ],
            ),
            delegate: SliverChildListDelegate([
              ContentCard(child: Icon(Icons.access_alarm_rounded)),
              ContentCard(child: Icon(Icons.read_more_rounded)),
              StatCard(statIcon: Icons.group_rounded,
                  statTitle: CommonState().testText(ref),
                  statNumber: 20),
            ]),
          ),
        ],
      ),
    );
  }
}
